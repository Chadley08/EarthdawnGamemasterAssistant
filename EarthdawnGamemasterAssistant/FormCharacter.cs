using EarthdawnGamemasterAssistant.Attributes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EarthdawnGamemasterAssistant.Racial;

namespace EarthdawnGamemasterAssistant
{
    public partial class FormCharacter : Form
    {
        private static readonly CharacterInfo CurrentCharacterInfo = new CharacterInfo();
        private static readonly List<Discipline> CurrentDisciplines = new List<Discipline>();

        public FormCharacter()
        {
            InitializeComponent();
        }

        private void numericUpDownStr_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Str = new Strength((int)numericUpDownStr.Value);
            metroLabelLiftingCapacity.Text = CurrentCharacterInfo.LiftingCapacity.ToString();
            metroLabelCarryingCapacity.Text = CurrentCharacterInfo.CarryingCapacity.ToString();
        }

        private void numericUpDownDex_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Dex = new Dexterity((int)numericUpDownDex.Value);
            metroLabelPhysicalDefense.Text = CurrentCharacterInfo.PhysicalDefense.ToString();
            metroLabelMovementLand.Text = CurrentCharacterInfo.MovementRate.ToString();
            metroLabelInitiativeDice.Text = CurrentCharacterInfo.InitiativeDice;
            metroLabelLandCombatMovementRate.Text = CurrentCharacterInfo.CombatMovementRate.ToString();
        }

        private void numericUpDownTou_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Tou = new Toughness((int) numericUpDownTou.Value);
            metroLabelDeathRating.Text = CurrentCharacterInfo.DeathRating.ToString();
            metroLabelUnconsciousnessRating.Text = CurrentCharacterInfo.UnconsciousnessRating.ToString();
            metroLabelWoundThreshold.Text = CurrentCharacterInfo.WoundThreshold.ToString();
            metroLabelRecoveryTests.Text = CurrentCharacterInfo.RecoveryTests.ToString();
        }

        private void numericUpDownPer_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Per = new Perception((int)numericUpDownPer.Value);
        }

        private void numericUpDownWil_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Wil = new Willpower((int)numericUpDownWil.Value);
            metroLabelMysticDefense.Text = CurrentCharacterInfo.MysticDefense.ToString();
        }

        private void numericUpDownChr_ValueChanged(object sender, EventArgs e)
        {
            CurrentCharacterInfo.Cha = new Charisma((int)numericUpDownChr.Value);
            metroLabelSocialDefense.Text = CurrentCharacterInfo.SocialDefense.ToString();
        }

        private void metroComboBoxRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (metroComboBoxRace.Text)
            {
                case "Dwarf":
                    var selectedRace = new Dwarf(CurrentCharacterInfo);
                    break;
            }

        }
    }
}