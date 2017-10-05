using System.Windows.Forms;

namespace EarthdawnGamemasterAssistant.UI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var formCharacter = new FormCharacterCreator();
            formCharacter.Show();
        }
    }
}