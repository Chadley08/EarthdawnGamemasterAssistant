﻿using EarthdawnGamemasterAssistant.Attributes;
using EarthdawnGamemasterAssistant.Disciplines;
using EarthdawnGamemasterAssistant.Racial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace EarthdawnGamemasterAssistant
{
    public partial class FormCharacterCreator : Form
    {
        private readonly CharacterInfo CurrentCharacterInfo = new CharacterInfo();

        public FormCharacterCreator()
        {
            InitializeComponent();

            CurrentCharacterInfo.PropertyChanged += CurrentCharacterInfoOnPropertyChanged;
            metroGridDisciplines.CellValueChanged += metroGridDisciplines_CellValueChanged;
            metroGridDisciplines.CurrentCellDirtyStateChanged += metroGridDisciplines_CurrentCellDirtyStateChanged;

            CurrentCharacterInfo.Disciplines = new List<Discipline>()
            {
                new AirSailor(new Circle(0)),
                new Archer(new Circle(0))
            };
            

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
                var selectedDiscipline = CurrentCharacterInfo.Disciplines.First(discipline => discipline.Name == disciplineName.ToString());
                    selectedDiscipline.AbilityRules.ForEach(abilityRule => abilityRule.Apply());
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
                    CalculateAttributePoints();
                    break;

                case "Str":
                    metroLabelLiftingCapacity.Text = CurrentCharacterInfo.LiftingCapacity.ToString();
                    metroLabelCarryingCapacity.Text = CurrentCharacterInfo.CarryingCapacity.ToString();
                    metroLabelAttributeTotalStr.Text =
                        (numericUpDownStr.Value + numericUpDownCircleStr.Value).ToString();
                    metroLabelAttributeStepStr.Text = CharacteristicTables
                        .GetStepFromValue(CurrentCharacterInfo.Str.Value)
                        .ToString();
                    CalculateAttributePoints();
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
                    CalculateAttributePoints();
                    break;

                case "Wil":
                    metroLabelMysticDefense.Text = CurrentCharacterInfo.MysticDefense.ToString();
                    metroLabelAttributeTotalWil.Text =
                        (numericUpDownWil.Value + numericUpDownCircleWil.Value).ToString();
                    metroLabelAttributeStepWil.Text = CharacteristicTables
                        .GetStepFromValue(CurrentCharacterInfo.Wil.Value)
                        .ToString();
                    CalculateAttributePoints();
                    break;

                case "Per":
                    metroLabelAttributeTotalPer.Text =
                        (numericUpDownPer.Value + numericUpDownCirclePer.Value).ToString();
                    metroLabelAttributeStepPer.Text = CharacteristicTables
                        .GetStepFromValue(CurrentCharacterInfo.Per.Value)
                        .ToString();
                    CalculateAttributePoints();
                    break;

                case "Cha":
                    metroLabelSocialDefense.Text = CurrentCharacterInfo.SocialDefense.ToString();
                    metroLabelAttributeTotalCha.Text =
                        (numericUpDownCha.Value + numericUpDownCircleCha.Value).ToString();
                    metroLabelAttributeStepCha.Text = CharacteristicTables
                        .GetStepFromValue(CurrentCharacterInfo.Cha.Value)
                        .ToString();
                    CalculateAttributePoints();
                    break;

                case "MaxKarma":
                    CalculateAttributePoints();
                    break;

                case "Race":
                    metroLabelMovementLand.Text = CurrentCharacterInfo.Race?.MovementRate.ToString() ?? "0";
                    CurrentCharacterInfo.MaxKarma = (int)numericUpDownMaxKarma.Value;
                    CalculateAttributePoints();
                    SetRacialAbilities();
                    break;
            }
        }

        private void SetRacialAbilities()
        {
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
            var cell = (DataGridViewComboBoxCell) metroGridDisciplines.SelectedRows[0].Cells[1];
            cell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
        }

        private void metroGridDisciplines_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            var cell = (DataGridViewComboBoxCell)metroGridDisciplines.SelectedRows[0].Cells[1];
            cell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
        }
    }
}