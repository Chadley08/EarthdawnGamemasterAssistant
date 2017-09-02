using EarthdawnGamemasterAssistant.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
                    if (CurrentCharacterInfo.Race != null)
                    {
                        AdjustPurchasedKarma();
                    }
                    break;
                case "Race":
                    metroLabelMovementLand.Text = CurrentCharacterInfo.Race?.MovementRate.ToString() ?? "0";
                    CurrentCharacterInfo.MaxKarma = (int)numericUpDownMaxKarma.Value;
                    AdjustPurchasedKarma();
                    CalculateAttributePoints();
                    break;
            }
        }

        private void AdjustPurchasedKarma()
        {
            var diff = numericUpDownMaxKarma.Value - CurrentCharacterInfo.Race?.KarmaModifier;
            if (diff > 0)
            {
                metroLabelPurchasedKarma.Text = diff.ToString();
            }
            else
            {
                metroLabelPurchasedKarma.Text = "0";
                numericUpDownMaxKarma.Value = (int)CurrentCharacterInfo.Race?.KarmaModifier;
            }
        }

        private void CalculateAttributePoints()
        {
            if (CurrentCharacterInfo.Race != null)
            {
                var dexCost = GetAttributePointCost(CurrentCharacterInfo.Dex.Value - CurrentCharacterInfo.Race.BaseDex.Value);
                var strCost = GetAttributePointCost(CurrentCharacterInfo.Str.Value - CurrentCharacterInfo.Race.BaseStr.Value);
                var touCost = GetAttributePointCost(CurrentCharacterInfo.Tou.Value - CurrentCharacterInfo.Race.BaseTou.Value);
                var perCost = GetAttributePointCost(CurrentCharacterInfo.Per.Value - CurrentCharacterInfo.Race.BasePer.Value);
                var wilCost = GetAttributePointCost(CurrentCharacterInfo.Wil.Value - CurrentCharacterInfo.Race.BaseWil.Value);
                var chaCost = GetAttributePointCost(CurrentCharacterInfo.Cha.Value - CurrentCharacterInfo.Race.BaseCha.Value);
                var totalCost = dexCost + strCost + touCost + perCost + wilCost + chaCost;

                metroLabelAttributesPointsAvailable.Text = (25 - totalCost).ToString();
                CurrentCharacterInfo.AvailableAttributePoints = 25 - totalCost;
            }
        }

        private int GetAttributePointCost(int difference)
        {
            var cost = -99999;
            switch (difference)
            {
                case -2:
                    cost = -2;
                    break;

                case -1:
                    cost = -1;
                    break;

                case 0:
                    cost = 0;
                    break;

                case 1:
                    cost = 1;
                    break;

                case 2:
                    cost = 2;
                    break;

                case 3:
                    cost = 3;
                    break;

                case 4:
                    cost = 5;
                    break;

                case 5:
                    cost = 7;
                    break;

                case 6:
                    cost = 9;
                    break;

                case 7:
                    cost = 12;
                    break;

                case 8:
                    cost = 15;
                    break;

                default:
                    if (difference < -2)
                    {
                        cost = -2;
                    }
                    Debug.WriteLine("Attribute is outside expected normal value range.");
                    if (difference > 8)
                    {
                        throw new Exception("Attribute value cannot be more than 8 of the race's base attribute value");
                    }
                    break;
            }
            return cost;
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