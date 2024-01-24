using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Snake
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            errorProvider1 = new ErrorProvider();
            btnStart.Enabled = false;
            btnConfirm.Click += btnConfirm_Click;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit the game?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                // Do nothing, let the Menu page remian open
            }
            else
            {
                this.Close();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Check if the textbox is empty when confirm button is clicked / pressed
            if (string.IsNullOrWhiteSpace(txtbUsername.Text))
            {
                errorProvider1.SetError(txtbUsername, "Please enter a username.");
                MessageBox.Show("Please enter a username.", "Username Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Do not enable the start button as the username is not entered.
                btnStart.Enabled = false;
            }
            else
            {
                //Username entered, start button become enable.
                btnStart.Enabled = true;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Enabled)
            {
                GameStats.userName = txtbUsername.Text.Trim();

                // Instantiate Selection form and pass the username to its constructor
                Selection selectionForm = new Selection(GameStats.userName);
                this.Hide();

                // Show the Selection form
                selectionForm.ShowDialog();

                // After the Selection form is closed, retrieve the selected difficulty and save the user data if needed
                if (selectionForm.DialogResult == DialogResult.OK)
                {


                    string selectedDifficulty = selectionForm.SelectedDifficulty;

                    // Combine username and difficulty into a single string
                    string userData = $"{GameStats.userName}, {selectedDifficulty}";

                    SaveNameToFile(GameStats.userName, selectedDifficulty);
                }
            }
        }

        private void SaveNameToFile(string username, string selectedDifficulty)
        {
            StreamWriter sw = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Game.txt"), append: true);
            string userData = $"{username}, {selectedDifficulty}";
            sw.WriteLine(userData);
            sw.Close();
        }

        
    }
}
