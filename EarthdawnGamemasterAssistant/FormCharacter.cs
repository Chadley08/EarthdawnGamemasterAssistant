using System.Windows.Forms;

namespace EarthdawnGamemasterAssistant
{
    public partial class FormCharacter : Form
    {
        private Character CurrentCharacter;

        public FormCharacter()
        {
            InitializeComponent();
        }

        private void metroComboBoxRace_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // [NOTE]: There are probably two use cases to work with here. The
            // case where the user wants to create a new character from scratch,
            // or the case where they want to keep all other selections made
            // (minus attributes).
            switch (metroComboBoxRace.Text)
            {
                case "Dwarf":
                    CurrentCharacter = Program.DefaultCharacters["Dwarf"];
                    break;
            }
            domainUpDownDex.Text = CurrentCharacter.Dex.Value.ToString();
        }
    }
}