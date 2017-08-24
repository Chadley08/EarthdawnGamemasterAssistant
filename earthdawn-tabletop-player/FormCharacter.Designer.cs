namespace earthdawn_tabletop_player
{
    partial class FormCharacter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroTabControl = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPageCharacter = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPageAttributes = new MetroFramework.Controls.MetroTabPage();
            this.metroTextBoxName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabelName = new MetroFramework.Controls.MetroLabel();
            this.metroTabControl.SuspendLayout();
            this.metroTabPageCharacter.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl
            // 
            this.metroTabControl.Controls.Add(this.metroTabPageCharacter);
            this.metroTabControl.Controls.Add(this.metroTabPageAttributes);
            this.metroTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.metroTabControl.HotTrack = true;
            this.metroTabControl.Location = new System.Drawing.Point(0, 0);
            this.metroTabControl.Name = "metroTabControl";
            this.metroTabControl.SelectedIndex = 0;
            this.metroTabControl.Size = new System.Drawing.Size(1819, 845);
            this.metroTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.metroTabControl.TabIndex = 0;
            this.metroTabControl.UseSelectable = true;
            // 
            // metroTabPageCharacter
            // 
            this.metroTabPageCharacter.Controls.Add(this.metroLabelName);
            this.metroTabPageCharacter.Controls.Add(this.metroTextBoxName);
            this.metroTabPageCharacter.HorizontalScrollbarBarColor = true;
            this.metroTabPageCharacter.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPageCharacter.HorizontalScrollbarSize = 10;
            this.metroTabPageCharacter.Location = new System.Drawing.Point(4, 38);
            this.metroTabPageCharacter.Name = "metroTabPageCharacter";
            this.metroTabPageCharacter.Size = new System.Drawing.Size(1811, 803);
            this.metroTabPageCharacter.TabIndex = 0;
            this.metroTabPageCharacter.Text = "Character";
            this.metroTabPageCharacter.VerticalScrollbarBarColor = true;
            this.metroTabPageCharacter.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPageCharacter.VerticalScrollbarSize = 10;
            // 
            // metroTabPageAttributes
            // 
            this.metroTabPageAttributes.HorizontalScrollbarBarColor = true;
            this.metroTabPageAttributes.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPageAttributes.HorizontalScrollbarSize = 10;
            this.metroTabPageAttributes.Location = new System.Drawing.Point(4, 38);
            this.metroTabPageAttributes.Name = "metroTabPageAttributes";
            this.metroTabPageAttributes.Size = new System.Drawing.Size(1811, 803);
            this.metroTabPageAttributes.TabIndex = 1;
            this.metroTabPageAttributes.Text = "Attributes";
            this.metroTabPageAttributes.VerticalScrollbarBarColor = true;
            this.metroTabPageAttributes.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPageAttributes.VerticalScrollbarSize = 10;
            // 
            // metroTextBoxName
            // 
            // 
            // 
            // 
            this.metroTextBoxName.CustomButton.Image = null;
            this.metroTextBoxName.CustomButton.Location = new System.Drawing.Point(221, 1);
            this.metroTextBoxName.CustomButton.Name = "";
            this.metroTextBoxName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxName.CustomButton.TabIndex = 1;
            this.metroTextBoxName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxName.CustomButton.UseSelectable = true;
            this.metroTextBoxName.CustomButton.Visible = false;
            this.metroTextBoxName.Lines = new string[0];
            this.metroTextBoxName.Location = new System.Drawing.Point(85, 15);
            this.metroTextBoxName.MaxLength = 32767;
            this.metroTextBoxName.Name = "metroTextBoxName";
            this.metroTextBoxName.PasswordChar = '\0';
            this.metroTextBoxName.PromptText = "Enter character name...";
            this.metroTextBoxName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxName.SelectedText = "";
            this.metroTextBoxName.SelectionLength = 0;
            this.metroTextBoxName.SelectionStart = 0;
            this.metroTextBoxName.ShortcutsEnabled = true;
            this.metroTextBoxName.Size = new System.Drawing.Size(243, 23);
            this.metroTextBoxName.TabIndex = 2;
            this.metroTextBoxName.UseSelectable = true;
            this.metroTextBoxName.WaterMark = "Enter character name...";
            this.metroTextBoxName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabelName
            // 
            this.metroLabelName.AutoSize = true;
            this.metroLabelName.Location = new System.Drawing.Point(8, 18);
            this.metroLabelName.Name = "metroLabelName";
            this.metroLabelName.Size = new System.Drawing.Size(45, 19);
            this.metroLabelName.TabIndex = 3;
            this.metroLabelName.Text = "Name";
            // 
            // FormCharacter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1819, 845);
            this.Controls.Add(this.metroTabControl);
            this.Name = "FormCharacter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Character Creator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.metroTabControl.ResumeLayout(false);
            this.metroTabPageCharacter.ResumeLayout(false);
            this.metroTabPageCharacter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl;
        private MetroFramework.Controls.MetroTabPage metroTabPageCharacter;
        private MetroFramework.Controls.MetroTabPage metroTabPageAttributes;
        private MetroFramework.Controls.MetroLabel metroLabelName;
        private MetroFramework.Controls.MetroTextBox metroTextBoxName;
    }
}