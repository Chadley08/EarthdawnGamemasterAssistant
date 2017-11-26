﻿using EarthdawnGamemasterAssistant.CharacterGenerator;
using EarthdawnGamemasterAssistant.CharacterGenerator.Attributes;
using EarthdawnGamemasterAssistant.CharacterGenerator.Disciplines;
using EarthdawnGamemasterAssistant.CharacterGenerator.Racial;
using EarthdawnGamemasterAssistant.CharacterGenerator.Talents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EarthdawnGamemasterAssistant.UI
{
    public partial class FormCharacterCreator : Form
    {
        private readonly CharacterInfo CurrentCharacterInfo = new CharacterInfo(
            new DisciplineSet(
                new List<IDiscipline>()
                {
                    new AirSailor(0),
                    new Archer(0)
                }));

        public FormCharacterCreator()
        {
            InitializeComponent();

            CurrentCharacterInfo.Disciplines.PropertyChanged += Disciplines_PropertyChanged;
            CurrentCharacterInfo.Disciplines.TalentRankChanged += Disciplines_TalentRankChanged;
            CurrentCharacterInfo.PropertyChanged += CurrentCharacterInfoOnPropertyChanged;
            metroGridDisciplines.CellValueChanged += metroGridDisciplines_CellValueChanged;
            metroGridDisciplines.CurrentCellDirtyStateChanged += metroGridDisciplines_CurrentCellDirtyStateChanged;

            // Load default attribute values into the view.
            CurrentCharacterInfo.Dex = new Dexterity(10);
            CurrentCharacterInfo.Str = new Strength(10);
            CurrentCharacterInfo.Tou = new Toughness(10);
            CurrentCharacterInfo.Per = new Perception(10);
            CurrentCharacterInfo.Wil = new Willpower(10);
            CurrentCharacterInfo.Cha = new Charisma(10);

            CurrentCharacterInfo.AvailableAttributePoints = 25;
            PopulateDisciplinesGrid();
            PopulateStepChart();
        }

        private void Disciplines_TalentRankChanged(object sender, PropertyChangedEventArgs e)
        {
            var talent = (Talent)sender;
            var attributeValue = CurrentCharacterInfo.GetMatchingAttribute(talent.BaseEarthdawnAttribute.Name).Value;
            var talentStep = talent.GetStep(attributeValue);
            var actionDice = CharacteristicTables.GetStepDice(talentStep);
            if (metroGridTalents.SelectedCells.Count > 0)
            {
                metroGridTalents.SelectedCells[0].OwningRow.Cells["ColumnStep"].Value = talentStep;
                metroGridTalents.SelectedCells[0].OwningRow.Cells["ColumnTalentActionDice"].Value = actionDice;
            }
        }

        private void Disciplines_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "EarthdawnCircle":
                    UpdateTalentGrid();
                    UpdateWarningControlsOnTalentsTab();

                    // [REVIEW]: Why just physical defense updates? Aren't there
                    // going to be others?
                    metroLabelPhysicalDefense.Text = CurrentCharacterInfo.PhysicalDefense.ToString();
                    break;
            }
        }

        private void UpdateTalentGrid()
        {
            // Remove talents from circle 0 disciplines
            var disciplineNames = CurrentCharacterInfo.Disciplines.GetCircleZeroDisciplineNames();
            var toRemove = (from DataGridViewRow row in metroGridTalents.Rows
                            let disciplineString = row.Cells["ColumnTalentDiscipline"].Value.ToString()
                            let disciplineList = disciplineString.Split(';')
                            from disciplineName in disciplineList
                            let index = disciplineName.IndexOf('(')
                            let toCompare = disciplineName.Substring(0, index).Trim()
                            where disciplineNames.Exists(_ => _.Contains(toCompare))
                            select row.Index).ToList();
            if (metroGridTalents.Rows.Count > 0)
            {
                for (var i = toRemove.Count - 1; i >= 0; i--)
                {
                    metroGridTalents.Rows.RemoveAt(i);
                }
            }

            // Add talents which currently do not exist in the grid to the grid.
            var disciplinedTalents = CurrentCharacterInfo.Disciplines.GetDisciplinedTalents();
            var availableTalents = CurrentCharacterInfo.Disciplines.AvailableTalents();
            foreach (var tuple in availableTalents)
            {
                if (TalentExistsInGrid(tuple.talent.Name))
                {
                    var row = GetRowByTalentName(tuple.talent.Name);
                    var talentName = tuple.talent.Name;
                    var talentAttribute = row.Cells["dataGridViewTextBoxColumnAttribute"].Value.ToString();
                    var matchingAttribute = CurrentCharacterInfo.GetMatchingAttribute(talentAttribute);
                    var talentRank = Convert.ToInt32(row.Cells["ColumnRank"].Value.ToString());
                    var talent = new Talent(
                        talentName,
                        "",
                        matchingAttribute,
                        talentRank,
                        tuple.talent.StepRule,
                        tuple.talent.Action,
                        tuple.talent.Strain,
                        tuple.talent.SkillUse);

                    var step = talent.GetStep(matchingAttribute.Value);

                    // Update the current talent row.
                    row.Cells["ColumnStep"].Value = talent.GetStep(matchingAttribute.Value);
                    row.Cells["ColumnTalentActionDice"].Value = CharacteristicTables.GetStepDice(step);
                    row.Cells["ColumnTalentDiscipline"].Value = tuple.disciplineName;
                }
                else
                {
                    // Create a new talent row from scratch.
                    var attributeValue =
                        CurrentCharacterInfo
                            .GetMatchingAttribute(tuple.talent.BaseEarthdawnAttribute.Name)
                            .Value;
                    var step = tuple.talent.GetStep(attributeValue);
                    var actionDice = CharacteristicTables.GetStepDice(step);
                    metroGridTalents.Rows.Add(
                        tuple.talent.Name,
                        tuple.talent.BaseEarthdawnAttribute.Name,
                        tuple.talent.Rank,
                        disciplinedTalents.Exists(talent => talent.Name == tuple.talent.Name) ? "Y" : "N",
                        tuple.disciplineName,
                        step,
                        actionDice);
                }
            }
        }

        private DataGridViewRow GetRowByTalentName(string talentName)
        {
            foreach (DataGridViewRow row in metroGridTalents.Rows)
            {
                if (row.Cells["dataGridViewTextBoxColumnName"].Value.ToString() == talentName)
                {
                    return row;
                }
            }
            throw new Exception("Row not found, but it should have been.");
        }

        private bool TalentExistsInGrid(string talentName)
        {
            return metroGridTalents.Rows.Cast<DataGridViewRow>()
                .Any(row => row.Cells["dataGridViewTextBoxColumnName"].Value.ToString() == talentName);
        }

        private void metroGridDisciplines_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (metroGridDisciplines.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                metroGridDisciplines.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void metroGridDisciplines_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var disciplineName = metroGridDisciplines.SelectedRows[0].Cells[0].Value;
            var changedCell = (DataGridViewComboBoxCell)metroGridDisciplines.Rows[e.RowIndex].Cells[1];
            if (changedCell.Value != null)
            {
                var selectedDiscipline =
                    CurrentCharacterInfo.Disciplines[disciplineName.ToString()];
                var newCircleValue = 0;
                if (changedCell.Value.ToString() != " ")
                {
                    newCircleValue = Convert.ToInt32(changedCell.Value);
                }
                selectedDiscipline.EarthdawnCircle = newCircleValue;
                metroGridDisciplines.Invalidate();
            }
        }

        private void PopulateDisciplinesGrid()
        {
            metroGridDisciplines.Rows.Add("Air Sailor", " ");
            metroGridDisciplines.Rows.Add("Archer", " ");
            metroGridDisciplines.Rows.Add("Beastmaster", " ");
            metroGridDisciplines.Rows.Add("Calvaryman", " ");
            metroGridDisciplines.Rows.Add("Elementalist", " ");
            metroGridDisciplines.Rows.Add("Illusionist", " ");
            metroGridDisciplines.Rows.Add("Nethermancer", " ");
            metroGridDisciplines.Rows.Add("Scout", " ");
            metroGridDisciplines.Rows.Add("Sky Raider", " ");
            metroGridDisciplines.Rows.Add("Sword Master", " ");
            metroGridDisciplines.Rows.Add("Thief", " ");
            metroGridDisciplines.Rows.Add("Troubadour", " ");
            metroGridDisciplines.Rows.Add("Warrior", " ");
            metroGridDisciplines.Rows.Add("Weaponsmith", " ");
            metroGridDisciplines.Rows.Add("Wizard", " ");
        }

        private void PopulateStepChart()
        {
            for (var i = 1; i <= 40; i++)
            {
                var dice = CharacteristicTables.GetStepDice(i);
                dataGridViewStepChart.Rows.Add(i, dice);
            }
        }

        private void CurrentCharacterInfoOnPropertyChanged(
            object sender,
            PropertyChangedEventArgs propertyChangedEventArgs)
        {
            switch (propertyChangedEventArgs.PropertyName)
            {
                case "Dex":
                    metroLabelPhysicalDefense.Text = CurrentCharacterInfo.PhysicalDefense.ToString();
                    metroLabelMovementLand.Text = CurrentCharacterInfo.MovementRate.ToString();
                    metroLabelInitiativeDice.Text = CurrentCharacterInfo.InitiativeDice;
                    metroLabelLandCombatMovementRate.Text = CurrentCharacterInfo.CombatMovementRate.ToString();
                    metroLabelAttributeTotalDex.Text =
                        (numericUpDownDex.Value + numericUpDownCircleDex.Value).ToString();
                    metroLabelAttributeStepDex.Text = CharacteristicTables
                        .GetStepFromValue(CurrentCharacterInfo.Dex.Value)
                        .ToString();
                    break;

                case "Str":
                    metroLabelLiftingCapacity.Text = CurrentCharacterInfo.LiftingCapacity.ToString();
                    metroLabelCarryingCapacity.Text = CurrentCharacterInfo.CarryingCapacity.ToString();
                    metroLabelAttributeTotalStr.Text =
                        (numericUpDownStr.Value + numericUpDownCircleStr.Value).ToString();
                    metroLabelAttributeStepStr.Text = CharacteristicTables
                        .GetStepFromValue(CurrentCharacterInfo.Str.Value)
                        .ToString();
                    break;

                case "Tou":
                    metroLabelDeathRating.Text = CurrentCharacterInfo.DeathRating.ToString();
                    metroLabelUnconsciousnessRating.Text = CurrentCharacterInfo.UnconsciousnessRating.ToString();
                    metroLabelWoundThreshold.Text = CurrentCharacterInfo.WoundThreshold.ToString();
                    metroLabelRecoveryTests.Text = CurrentCharacterInfo.RecoveryTests.ToString();
                    metroLabelAttributeTotalTou.Text =
                        (numericUpDownTou.Value + numericUpDownCircleTou.Value).ToString();
                    metroLabelAttributeStepTou.Text = CharacteristicTables
                        .GetStepFromValue(CurrentCharacterInfo.Tou.Value)
                        .ToString();
                    break;

                case "Wil":
                    metroLabelMysticDefense.Text = CurrentCharacterInfo.MysticDefense.ToString();
                    metroLabelAttributeTotalWil.Text =
                        (numericUpDownWil.Value + numericUpDownCircleWil.Value).ToString();
                    metroLabelAttributeStepWil.Text = CharacteristicTables
                        .GetStepFromValue(CurrentCharacterInfo.Wil.Value)
                        .ToString();
                    break;

                case "Per":
                    metroLabelAttributeTotalPer.Text =
                        (numericUpDownPer.Value + numericUpDownCirclePer.Value).ToString();
                    metroLabelAttributeStepPer.Text = CharacteristicTables
                        .GetStepFromValue(CurrentCharacterInfo.Per.Value)
                        .ToString();
                    break;

                case "Cha":
                    metroLabelSocialDefense.Text = CurrentCharacterInfo.SocialDefense.ToString();
                    metroLabelAttributeTotalCha.Text =
                        (numericUpDownCha.Value + numericUpDownCircleCha.Value).ToString();
                    metroLabelAttributeStepCha.Text = CharacteristicTables
                        .GetStepFromValue(CurrentCharacterInfo.Cha.Value)
                        .ToString();
                    break;

                case "MaxKarma":
                    break;

                case "Race":
                    metroLabelMovementLand.Text = CurrentCharacterInfo.Race?.MovementRate.ToString() ?? "0";
                    CurrentCharacterInfo.MaxKarma = (int)numericUpDownMaxKarma.Value;
                    metroLabelCarryingCapacity.Text = CurrentCharacterInfo.CarryingCapacity.ToString();
                    UpdateRacialAbilities();
                    break;
            }
            UpdateTalentGrid();
            CalculateAttributePoints();
        }

        private void UpdateRacialAbilities()
        {
            dataGridViewRacialAbilities.Rows.Clear();
            var racials = CurrentCharacterInfo.Race.GetRacialAbilities().ToList();
            racials.ForEach(
                racial =>
                {
                    dataGridViewRacialAbilities.Rows.Add(
                        racial.Name,
                        racial.Description);
                });
            dataGridViewRacialAbilities.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void CalculateAttributePoints()
        {
            if (CurrentCharacterInfo.Race != null)
            {
                var dexCost =
                    CharacteristicTables.GetAttributePointCost(
                        CurrentCharacterInfo.Dex.Value - Convert.ToInt32(numericUpDownCircleDex.Value) - CurrentCharacterInfo.Race.BaseDex.Value);
                var strCost =
                    CharacteristicTables.GetAttributePointCost(
                        CurrentCharacterInfo.Str.Value - Convert.ToInt32(numericUpDownCircleStr.Value) - CurrentCharacterInfo.Race.BaseStr.Value);
                var touCost =
                    CharacteristicTables.GetAttributePointCost(
                        CurrentCharacterInfo.Tou.Value - Convert.ToInt32(numericUpDownCircleTou.Value) - CurrentCharacterInfo.Race.BaseTou.Value);
                var perCost =
                    CharacteristicTables.GetAttributePointCost(
                        CurrentCharacterInfo.Per.Value - Convert.ToInt32(numericUpDownCirclePer.Value) - CurrentCharacterInfo.Race.BasePer.Value);
                var wilCost =
                    CharacteristicTables.GetAttributePointCost(
                        CurrentCharacterInfo.Wil.Value - Convert.ToInt32(numericUpDownCircleWil.Value) - CurrentCharacterInfo.Race.BaseWil.Value);
                var chaCost =
                    CharacteristicTables.GetAttributePointCost(
                        CurrentCharacterInfo.Cha.Value - Convert.ToInt32(numericUpDownCircleCha.Value) - CurrentCharacterInfo.Race.BaseCha.Value);

                // MaxKarma calculation
                var diff = numericUpDownMaxKarma.Value - CurrentCharacterInfo.Race.KarmaModifier;
                metroLabelPurchasedKarma.Text = diff > 0 ? diff.ToString() : "0";

                var totalCost = 0;
                if (diff > 0)
                {
                    totalCost = dexCost + strCost + touCost + perCost + wilCost + chaCost + (int)diff;
                }
                else
                {
                    totalCost = dexCost + strCost + touCost + perCost + wilCost + chaCost;
                }

                metroLabelAttributesPointsAvailable.Text = (25 - totalCost).ToString();
                CurrentCharacterInfo.AvailableAttributePoints = 25 - (int)totalCost;
            }
        }

        private void numericUpDownStr_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Str = new Strength((int)numericUpDownStr.Value);
        }

        private void numericUpDownDex_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Dex = new Dexterity((int)numericUpDownDex.Value);
        }

        private void numericUpDownTou_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Tou = new Toughness((int)numericUpDownTou.Value);
        }

        private void numericUpDownPer_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Per = new Perception((int)numericUpDownPer.Value);
        }

        private void numericUpDownWil_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Wil = new Willpower((int)numericUpDownWil.Value);
        }

        private void numericUpDownCha_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Cha = new Charisma((int)numericUpDownCha.Value);
        }

        private void metroComboBoxRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (metroComboBoxRace.Text)
            {
                case "Dwarf":
                    CurrentCharacterInfo.Race = new Dwarf(CurrentCharacterInfo);
                    break;

                case "Elf":
                    CurrentCharacterInfo.Race = new Elf(CurrentCharacterInfo);
                    break;
            }
        }

        private void numericUpDownMaxKarma_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.MaxKarma = (int)numericUpDownMaxKarma.Value;
        }

        private void numericUpDownCircleDex_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Dex = new Dexterity((int)(numericUpDownDex.Value + numericUpDownCircleDex.Value));
        }

        private void numericUpDownCircleStr_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Str = new Strength((int)(numericUpDownStr.Value + numericUpDownCircleStr.Value));
        }

        private void numericUpDownCircleTou_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Tou = new Toughness((int)(numericUpDownTou.Value + numericUpDownCircleTou.Value));
        }

        private void numericUpDownCirclePer_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Per = new Perception((int)(numericUpDownPer.Value + numericUpDownCirclePer.Value));
        }

        private void numericUpDownCircleWil_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Wil = new Willpower((int)(numericUpDownWil.Value + numericUpDownCircleWil.Value));
        }

        private void numericUpDownCircleCha_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Cha = new Charisma((int)(numericUpDownCha.Value + numericUpDownCircleCha.Value));
        }

        private void metroGridDisciplines_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (metroGridDisciplines.SelectedRows.Count <= 0)
            {
                return;
            }
            var cell = (DataGridViewComboBoxCell)metroGridDisciplines.SelectedRows[0].Cells[1];
            cell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
        }

        private void metroGridDisciplines_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            var cell = (DataGridViewComboBoxCell)metroGridDisciplines.SelectedRows[0].Cells[1];
            cell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
        }

        private void metroGridDisciplines_SelectionChanged(object sender, EventArgs e)
        {
            var disciplineName = metroGridDisciplines.SelectedRows[0].Cells[0].Value.ToString();
            var selectedDiscipline = CurrentCharacterInfo.Disciplines[disciplineName];
            DisplaySelectedDiscipline(selectedDiscipline);
        }

        private void DisplaySelectedDiscipline(IDiscipline selectedDiscipline)
        {
            metroLabelDisciplineDescription.Text = selectedDiscipline?.Description;

            metroLabelImportantAttirbutes.Text = string.Empty;
            selectedDiscipline?.ImportantAttributes.ToList()
                .ForEach(attribute => metroLabelImportantAttirbutes.Text += attribute.ToString() + "\r\n");

            metroGridFreeTalent.Rows.Clear();
            var freeTalent = selectedDiscipline?.FreeTalent;
            if (freeTalent is NullTalent)
            {
                // NO-OP
            }
            else
            {
                metroGridFreeTalent.Rows.Add(
                    freeTalent?.Name,
                    freeTalent?.BaseEarthdawnAttribute.Name,
                    freeTalent?.Action.ToString(),
                    freeTalent?.Strain,
                    freeTalent?.SkillUse.ToString());
            }

            metroGridNoviceTalents.Rows.Clear();
            selectedDiscipline?.NoviceTalentOptions?.ToList()
                .ForEach(
                    noviceTalent =>
                        metroGridNoviceTalents.Rows.Add(
                            noviceTalent?.Name,
                            noviceTalent?.BaseEarthdawnAttribute.Name,
                            noviceTalent?.Action.ToString(),
                            noviceTalent?.Strain,
                            noviceTalent?.SkillUse.ToString()));

            metroGridJourneymanTalents.Rows.Clear();
            selectedDiscipline?.JourneymanTalentOptions.ToList()
                .ForEach(
                    journeymanTalent => metroGridJourneymanTalents.Rows.Add(
                        journeymanTalent?.Name,
                        journeymanTalent?.BaseEarthdawnAttribute.Name,
                        journeymanTalent?.Action.ToString(),
                        journeymanTalent?.Strain,
                        journeymanTalent?.SkillUse.ToString()));

            metroGridDisciplinedTalentsAtCircle.Rows.Clear();
            if (selectedDiscipline?.TalentsAtCircle != null)
            {
                foreach (var key in selectedDiscipline?.TalentsAtCircle.Keys)
                {
                    selectedDiscipline.TalentsAtCircle[key]
                        .ForEach(
                            talent => metroGridDisciplinedTalentsAtCircle.Rows.Add(
                                talent.Name,
                                talent.BaseEarthdawnAttribute.Name,
                                talent.Action.ToString(),
                                talent.Strain,
                                talent.SkillUse.ToString(),
                                key.ToString()));
                }
            }

            metroGridAbilities.Rows.Clear();
            selectedDiscipline?.InitiativeAbilityRules?.ToList()
                .ForEach(
                    abilityRule => metroGridAbilities.Rows.Add(
                        abilityRule.Description,
                        abilityRule.BonusAmount,
                        abilityRule.CircleRequirement));
            selectedDiscipline?.PhysicalDefenseAbilityRules.ToList()
                .ForEach(
                    abilityRule => metroGridAbilities.Rows.Add(
                        abilityRule.Description,
                        abilityRule.BonusAmount,
                        abilityRule.CircleRequirement));
            selectedDiscipline?.MysticDefenseAbilityRules?.ToList()
                .ForEach(
                    abilityRule => metroGridAbilities.Rows.Add(
                        abilityRule.Description,
                        abilityRule.BonusAmount,
                        abilityRule.CircleRequirement));
            selectedDiscipline?.SocialDefenseAbilityRules?.ToList()
                .ForEach(
                    abilityRule => metroGridAbilities.Rows.Add(
                        abilityRule.Description,
                        abilityRule.BonusAmount,
                        abilityRule.CircleRequirement));
            selectedDiscipline?.KarmaAbilityRules?.ToList()
                .ForEach(
                    abilityRule => metroGridAbilities.Rows.Add(
                        abilityRule.Description,
                        abilityRule.BonusAmount,
                        abilityRule.CircleRequirement));
            selectedDiscipline?.GeneralAbilityRules?.ToList()
                .ForEach(
                    abilityRule => metroGridAbilities.Rows.Add(
                        abilityRule.Description,
                        abilityRule.BonusAmount,
                        abilityRule.CircleRequirement));
            selectedDiscipline?.RecoveryTestAbilityRules?.ToList()
                .ForEach(
                    abilityRule => metroGridAbilities.Rows.Add(
                        abilityRule.Description,
                        abilityRule.BonusAmount,
                        abilityRule.CircleRequirement));
            metroGridAbilities.Sort(metroGridAbilities.Columns[2], ListSortDirection.Ascending);
        }

        private void metroGridTalents_EditingControlShowing(object sender,
            DataGridViewEditingControlShowingEventArgs e)
        {
            var cb = e.Control as ComboBox;
            if (cb == null) return;

            // First remove event handler to keep from attaching multiple times
            cb.SelectedValueChanged -= Cb_SelectedValueChanged;
            cb.DropDown -= Cb_DropDown;

            // Now attach the event handler
            cb.SelectedValueChanged += Cb_SelectedValueChanged;
            cb.DropDown += Cb_DropDown;
        }

        private void Cb_DropDown(object sender, EventArgs e)
        {
            ((ComboBox)sender).BackColor = Color.White;
        }

        private void Cb_SelectedValueChanged(object sender, EventArgs e)
        {
            if (metroGridTalents.SelectedCells.Count > 0)
            {
                var talentRowIndex = metroGridTalents.SelectedCells[0].RowIndex;
                var talentName = metroGridTalents.Rows[talentRowIndex].Cells[0].Value.ToString();
                var selectedTalent = CurrentCharacterInfo.Disciplines.AvailableTalents()
                    .First(tuple => tuple.talent.Name == talentName).talent;
                selectedTalent.Rank = Convert.ToInt32(((DataGridViewComboBoxEditingControl)sender).SelectedItem);
                UpdateWarningControlsOnTalentsTab();
            }
        }

        private List<(string talentName, int talentRank)> GetCurrentTalents()
        {
            var currentTalentTuples = new List<(string talentName, int talentRank)>();
            foreach (DataGridViewRow talentRow in metroGridTalents.Rows)
            {
                var name = talentRow.Cells[0].Value.ToString();
                var rank = Convert.ToInt32(talentRow.Cells[2].EditedFormattedValue);
                currentTalentTuples.Add(
                    ValueTuple.Create(name, rank));
            }
            return currentTalentTuples;
        }

        private void UpdateWarningControlsOnTalentsTab()
        {
            flowLayoutPanelTalents.Controls.Clear();
            var currentTalents = GetCurrentTalents();
            var circleWarningTuples = CurrentCharacterInfo.Disciplines.GetCircleAdvancementRuleViolations(currentTalents);
            foreach (var circleWarningTuple in circleWarningTuples)
            {
                var warningIcon = new PictureBox
                {
                    Image = Properties.Resources.warning_0V8_icon,
                    Size = new System.Drawing.Size(24, 24),
                    TabIndex = 1,
                    TabStop = false
                };

                var warningLabel = new Label
                {
                    AutoSize = true,
                    Margin = new Padding(3, 7, 3, 0),
                    Size = new System.Drawing.Size(83, 19),
                    TabIndex = 0,
                    Text = circleWarningTuple.disciplineName +
                           @": Must have all disciplined talents at rank " +
                           circleWarningTuple.disciplineCircle
                };

                // [TODO]: Add an onclick event which auto completes requirements
                // not met.
                flowLayoutPanelTalents.Controls.Add(warningIcon);
                flowLayoutPanelTalents.Controls.Add(warningLabel);
            }
        }

        private void metroGridTalents_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var validClick = (e.RowIndex != -1 && e.ColumnIndex != -1); //Make sure the clicked row/column is valid.
            var datagridview = sender as DataGridView;

            // Check to make sure the cell clicked is the cell containing the combobox
            if (datagridview?.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && validClick)
            {
                datagridview.BeginEdit(true);
                ((ComboBox)datagridview.EditingControl).DroppedDown = true;
            }
        }

        private void metroGridTalents_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }
    }
}