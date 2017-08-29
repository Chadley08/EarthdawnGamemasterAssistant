using System.Collections.Generic;
using System.Windows.Forms;
using EarthdawnGamemasterAssistant.Racial;

namespace EarthdawnGamemasterAssistant
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var formCharacter = new FormCharacter();
            formCharacter.Show();
        }
    }
}