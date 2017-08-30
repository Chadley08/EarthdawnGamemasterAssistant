using System;
using System.Linq;
using System.Windows.Forms;

namespace EarthdawnGamemasterAssistant
{
    public partial class FormCharacter : Form
    {
        private Character CurrentCharacter;

        public FormCharacter()
        {
            InitializeComponent();
            InitializeFields();
        }

        private void InitializeFields()
        {
            domainUpDownCircleDex.Text = @"3";
            domainUpDownCircleStr.Text = @"0";
            domainUpDownCircleTou.Text = @"0";
            domainUpDownCirclePer.Text = @"0";
            domainUpDownCircleWil.Text = @"0";
            domainUpDownCircleChr.Text = @"0";
        }

        private void metroComboBoxRace_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (metroComboBoxRace.Text)
            {
                case "Dwarf":
                    CurrentCharacter = Program.DefaultCharacters["Dwarf"];
                    break;
            }
            domainUpDownDex.Text = CurrentCharacter.Dex.Value.ToString();
            domainUpDownStr.Text = CurrentCharacter.Str.Value.ToString();
            domainUpDownTou.Text = CurrentCharacter.Tou.Value.ToString();
            domainUpDownPer.Text = CurrentCharacter.Per.Value.ToString();
            domainUpDownWil.Text = CurrentCharacter.Wil.Value.ToString();
            domainUpDownChr.Text = CurrentCharacter.Chr.Value.ToString();

            UpdateTotalAttributeValues();
            UpdateAttributeStepValues();
            UpdateInitiative();
            UpdateDefenses();
            UpdateArmor();
            UpdateDamage();
            UpdateCapacity();
            UpdateKarma();
            UpdateMovement();
        }

        private void UpdateInitiative()
        {
            metroLabelInitiativeDice.Text =
                CharacteristicTables.GetStepDice(Convert.ToInt32(CurrentCharacter.Dex.Value));
        }

        private void UpdateAttributeStepValues()
        {
            metroLabelAttributeStepDex.Text = CharacteristicTables.GetStepFromValue(Convert.ToInt32(metroLabelAttributeTotalDex.Text.Replace("(", "").Replace(")", ""))).ToString();
            metroLabelAttributeStepStr.Text = CharacteristicTables.GetStepFromValue(Convert.ToInt32(metroLabelAttributeTotalStr.Text.Replace("(", "").Replace(")", ""))).ToString();
            metroLabelAttributeStepTou.Text = CharacteristicTables.GetStepFromValue(Convert.ToInt32(metroLabelAttributeTotalTou.Text.Replace("(", "").Replace(")", ""))).ToString();
            metroLabelAttributeStepPer.Text = CharacteristicTables.GetStepFromValue(Convert.ToInt32(metroLabelAttributeTotalPer.Text.Replace("(", "").Replace(")", ""))).ToString();
            metroLabelAttributeStepWil.Text = CharacteristicTables.GetStepFromValue(Convert.ToInt32(metroLabelAttributeTotalWil.Text.Replace("(", "").Replace(")", ""))).ToString();
            metroLabelAttributeStepChr.Text = CharacteristicTables.GetStepFromValue(Convert.ToInt32(metroLabelAttributeTotalChr.Text.Replace("(", "").Replace(")", ""))).ToString();
        }

        private void UpdateTotalAttributeValues()
        {
            var total = Convert.ToDouble(domainUpDownDex.Text) + Convert.ToDouble(domainUpDownCircleDex.Text);
            metroLabelAttributeTotalDex.Text = @"(" + total + @")";

            total = Convert.ToDouble(domainUpDownStr.Text) + Convert.ToDouble(domainUpDownCircleStr.Text);
            metroLabelAttributeTotalStr.Text = @"(" + total + @")";

            total = Convert.ToDouble(domainUpDownTou.Text) + Convert.ToDouble(domainUpDownCircleTou.Text);
            metroLabelAttributeTotalTou.Text = @"(" + total + @")";

            total = Convert.ToDouble(domainUpDownPer.Text) + Convert.ToDouble(domainUpDownCirclePer.Text);
            metroLabelAttributeTotalPer.Text = @"(" + total + @")";

            total = Convert.ToDouble(domainUpDownWil.Text) + Convert.ToDouble(domainUpDownCircleWil.Text);
            metroLabelAttributeTotalWil.Text = @"(" + total + @")";

            total = Convert.ToDouble(domainUpDownChr.Text) + Convert.ToDouble(domainUpDownCircleChr.Text);
            metroLabelAttributeTotalChr.Text = @"(" + total + @")";
        }
    }
}