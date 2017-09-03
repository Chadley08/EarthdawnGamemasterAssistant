using EarthdawnGamemasterAssistant.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using EarthdawnGamemasterAssistant.Racial;

namespace EarthdawnGamemasterAssistant
{
    public partial class FormCharacter : Form
    {
        private readonly CharacterInfo CurrentCharacterInfo = new CharacterInfo();
        private readonly List<Discipline> CurrentDisciplines = new List<Discipline>();

        public FormCharacter()
        {
            InitializeComponent();
            CurrentCharacterInfo.PropertyChanged += CurrentCharacterInfoOnPropertyChanged;

            CurrentCharacterInfo.Dex = new Dexterity(10);
            CurrentCharacterInfo.Str = new Strength(10);
            CurrentCharacterInfo.Tou = new Toughness(10);
            CurrentCharacterInfo.Per = new Perception(10);
            CurrentCharacterInfo.Wil = new Willpower(10);
            CurrentCharacterInfo.Cha = new Charisma(10);
            CurrentCharacterInfo.AvailableAttributePoints = 25;
        }

        private void CurrentCharacterInfoOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            switch (propertyChangedEventArgs.PropertyName)
            {
                case "Dex":
                    metroLabelPhysicalDefense.Text = CurrentCharacterInfo.PhysicalDefense.ToString();
                    metroLabelMovementLand.Text = CurrentCharacterInfo.MovementRate.ToString();
                    metroLabelInitiativeDice.Text = CurrentCharacterInfo.InitiativeDice;
                    metroLabelLandCombatMovementRate.Text = CurrentCharacterInfo.CombatMovementRate.ToString();
                    CalculateAttributePoints();
                    break;
                case "Str":
                    metroLabelLiftingCapacity.Text = CurrentCharacterInfo.LiftingCapacity.ToString();
                    metroLabelCarryingCapacity.Text = CurrentCharacterInfo.CarryingCapacity.ToString();
                    CalculateAttributePoints();
                    break;
                case "Tou":
                    metroLabelDeathRating.Text = CurrentCharacterInfo.DeathRating.ToString();
                    metroLabelUnconsciousnessRating.Text = CurrentCharacterInfo.UnconsciousnessRating.ToString();
                    metroLabelWoundThreshold.Text = CurrentCharacterInfo.WoundThreshold.ToString();
                    metroLabelRecoveryTests.Text = CurrentCharacterInfo.RecoveryTests.ToString();
                    CalculateAttributePoints();
                    break;
                case "Wil":
                    metroLabelMysticDefense.Text = CurrentCharacterInfo.MysticDefense.ToString();
                    CalculateAttributePoints();
                    break;
                case "Per":
                    CalculateAttributePoints();
                    break;
                case "Cha":
                    metroLabelSocialDefense.Text = CurrentCharacterInfo.SocialDefense.ToString();
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
            racials.ForEach(racial => dataGridViewRacialAbilities.Rows.Add(
                racial.Name,
                racial.Description));
            dataGridViewRacialAbilities.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            
        }

        private void CalculateAttributePoints()
        {
            if (CurrentCharacterInfo.Race != null)
            {
                var dexCost = CharacteristicTables.GetAttributePointCost(CurrentCharacterInfo.Dex.Value - CurrentCharacterInfo.Race.BaseDex.Value);
                var strCost = CharacteristicTables.GetAttributePointCost(CurrentCharacterInfo.Str.Value - CurrentCharacterInfo.Race.BaseStr.Value);
                var touCost = CharacteristicTables.GetAttributePointCost(CurrentCharacterInfo.Tou.Value - CurrentCharacterInfo.Race.BaseTou.Value);
                var perCost = CharacteristicTables.GetAttributePointCost(CurrentCharacterInfo.Per.Value - CurrentCharacterInfo.Race.BasePer.Value);
                var wilCost = CharacteristicTables.GetAttributePointCost(CurrentCharacterInfo.Wil.Value - CurrentCharacterInfo.Race.BaseWil.Value);
                var chaCost = CharacteristicTables.GetAttributePointCost(CurrentCharacterInfo.Cha.Value - CurrentCharacterInfo.Race.BaseCha.Value);

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
            CurrentCharacterInfo.Tou = new Toughness((int) numericUpDownTou.Value);
        }

        private void numericUpDownPer_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Per = new Perception((int)numericUpDownPer.Value);
        }

        private void numericUpDownWil_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Wil = new Willpower((int)numericUpDownWil.Value);
        }

        private void numericUpDownChr_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Cha = new Charisma((int)numericUpDownChr.Value);
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
    }
}