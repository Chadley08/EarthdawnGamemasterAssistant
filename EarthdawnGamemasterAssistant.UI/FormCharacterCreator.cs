using EarthdawnGamemasterAssistant.CharacterGenerator;
using EarthdawnGamemasterAssistant.CharacterGenerator.Attributes;
using EarthdawnGamemasterAssistant.CharacterGenerator.Disciplines;
using EarthdawnGamemasterAssistant.CharacterGenerator.Racial;
using EarthdawnGamemasterAssistant.CharacterGenerator.Talents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            var talent = (Talent) sender;
            var attributeValue = CurrentCharacterInfo.GetMatchingAttribute(talent.BaseEarthdawnAttribute).Value;
            var talentStep = talent.GetStep(attributeValue);
            var actionDice = CharacteristicTables.GetStepDice(talentStep);
            metroGridTalents.SelectedCells[0].OwningRow.Cells["ColumnStep"].Value = talentStep;
            metroGridTalents.SelectedCells[0].OwningRow.Cells["ColumnTalentActionDice"].Value = actionDice;
        }

        private void Disciplines_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "EarthdawnCircle":
                    UpdateTalentGrid();

                    // The circle changed, so we have to update the PhysicalDefense rating.
                    metroLabelPhysicalDefense.Text = CurrentCharacterInfo.PhysicalDefense.ToString();
                    break;
            }
        }

        private void UpdateTalentGrid()
        {
            // Clear the current grid
            metroGridTalents.Rows.Clear();

            // Get all the talents available for each discipline with a cirlce higher than 0
            CurrentCharacterInfo.Disciplines.AvailableTalents()
                .ForEach(
                    tuple =>
                    {
                        var attributeValue = CurrentCharacterInfo.GetMatchingAttribute(tuple.talent.BaseEarthdawnAttribute)
                            .Value;
                        var step = tuple.talent.GetStep(attributeValue);
                        var actionDice = CharacteristicTables.GetStepDice(step);
                        metroGridTalents.Rows.Add(
                            tuple.talent.Name,
                            tuple.talent.BaseEarthdawnAttribute.Name,
                            tuple.talent.Rank,
                            tuple.disciplineName,
                            step,
                            actionDice);
                    });
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
            var changedCell = (DataGridViewComboBoxCell) metroGridDisciplines.Rows[e.RowIndex].Cells[1];
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
                    CurrentCharacterInfo.MaxKarma = (int) numericUpDownMaxKarma.Value;
                    metroLabelCarryingCapacity.Text = CurrentCharacterInfo.CarryingCapacity.ToString();
                    SetRacialAbilities();
                    break;
            }
            UpdateTalentGrid();
            CalculateAttributePoints();
        }

        private void SetRacialAbilities()
        {
            dataGridViewRacialAbilities.Rows.Clear();
            var racials = CurrentCharacterInfo.Race.GetRacialAbilities().ToList();
            racials.ForEach(
                racial => dataGridViewRacialAbilities.Rows.Add(
                    racial.Name,
                    racial.Description));
            dataGridViewRacialAbilities.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void CalculateAttributePoints()
        {
            if (CurrentCharacterInfo.Race != null)
            {
                var dexCost =
                    CharacteristicTables.GetAttributePointCost(
                        CurrentCharacterInfo.Dex.Value - CurrentCharacterInfo.Race.BaseDex.Value);
                var strCost =
                    CharacteristicTables.GetAttributePointCost(
                        CurrentCharacterInfo.Str.Value - CurrentCharacterInfo.Race.BaseStr.Value);
                var touCost =
                    CharacteristicTables.GetAttributePointCost(
                        CurrentCharacterInfo.Tou.Value - CurrentCharacterInfo.Race.BaseTou.Value);
                var perCost =
                    CharacteristicTables.GetAttributePointCost(
                        CurrentCharacterInfo.Per.Value - CurrentCharacterInfo.Race.BasePer.Value);
                var wilCost =
                    CharacteristicTables.GetAttributePointCost(
                        CurrentCharacterInfo.Wil.Value - CurrentCharacterInfo.Race.BaseWil.Value);
                var chaCost =
                    CharacteristicTables.GetAttributePointCost(
                        CurrentCharacterInfo.Cha.Value - CurrentCharacterInfo.Race.BaseCha.Value);

                // MaxKarma calculation
                var diff = numericUpDownMaxKarma.Value - CurrentCharacterInfo.Race.KarmaModifier;
                metroLabelPurchasedKarma.Text = diff > 0 ? diff.ToString() : "0";

                var totalCost = 0;
                if (diff > 0)
                {
                    totalCost = dexCost + strCost + touCost + perCost + wilCost + chaCost + (int) diff;
                }
                else
                {
                    totalCost = dexCost + strCost + touCost + perCost + wilCost + chaCost;
                }

                metroLabelAttributesPointsAvailable.Text = (25 - totalCost).ToString();
                CurrentCharacterInfo.AvailableAttributePoints = 25 - (int) totalCost;
            }
        }

        private void numericUpDownStr_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Str = new Strength((int) numericUpDownStr.Value);
        }

        private void numericUpDownDex_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Dex = new Dexterity((int) numericUpDownDex.Value);
        }

        private void numericUpDownTou_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Tou = new Toughness((int) numericUpDownTou.Value);
        }

        private void numericUpDownPer_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Per = new Perception((int) numericUpDownPer.Value);
        }

        private void numericUpDownWil_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Wil = new Willpower((int) numericUpDownWil.Value);
        }

        private void numericUpDownCha_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Cha = new Charisma((int) numericUpDownCha.Value);
        }

        private void metroComboBoxRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (metroComboBoxRace.Text)
            {
                case "Dwarf":
                    CurrentCharacterInfo.Race = new Dwarf(CurrentCharacterInfo);
                    break;
            }
        }

        private void numericUpDownMaxKarma_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.MaxKarma = (int) numericUpDownMaxKarma.Value;
        }

        private void numericUpDownCircleDex_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Dex = new Dexterity((int) (numericUpDownDex.Value + numericUpDownCircleDex.Value));
        }

        private void numericUpDownCircleStr_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Str = new Strength((int) (numericUpDownStr.Value + numericUpDownCircleStr.Value));
        }

        private void numericUpDownCircleTou_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Tou = new Toughness((int) (numericUpDownTou.Value + numericUpDownCircleTou.Value));
        }

        private void numericUpDownCirclePer_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Per = new Perception((int) (numericUpDownPer.Value + numericUpDownCirclePer.Value));
        }

        private void numericUpDownCircleWil_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Wil = new Willpower((int) (numericUpDownWil.Value + numericUpDownCircleWil.Value));
        }

        private void numericUpDownCircleCha_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Cha = new Charisma((int) (numericUpDownCha.Value + numericUpDownCircleCha.Value));
        }

        private void metroGridDisciplines_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (metroGridDisciplines.SelectedRows.Count <= 0)
            {
                return;
            }
            var cell = (DataGridViewComboBoxCell) metroGridDisciplines.SelectedRows[0].Cells[1];
            cell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
        }

        private void metroGridDisciplines_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            var cell = (DataGridViewComboBoxCell) metroGridDisciplines.SelectedRows[0].Cells[1];
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
            cb.SelectedIndexChanged -= ComboBoxTalent_SelectedIndexChanged;

            // Now attach the event handler
            cb.SelectedIndexChanged += ComboBoxTalent_SelectedIndexChanged;
        }

        private void ComboBoxTalent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroGridTalents.SelectedCells.Count > 0)
            {
                var talentRowIndex = metroGridTalents.SelectedCells[0].RowIndex;
                var talentName = metroGridTalents.Rows[talentRowIndex].Cells[0].Value.ToString();
                var selectedTalent = CurrentCharacterInfo.Disciplines.AvailableTalents()
                    .First(tuple => tuple.talent.Name == talentName).talent;
                selectedTalent.Rank = Convert.ToInt32(((DataGridViewComboBoxEditingControl)sender).SelectedItem);
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