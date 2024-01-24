using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Selection : Form
    {
        private string username;

        public string SelectedDifficulty { get; private set; }

        public Selection(string username)
        {
            InitializeComponent();

            lblGameDescription.AutoSize = false;
            lblGameDescription.Size = new Size(600, 600);

            btnEasy.MouseEnter += BtnEasy_MouseEnter;
            btnEasy.MouseLeave += BtnEasy_MouseLeave;

            btnMedium.MouseEnter += btnMedium_MouseEnter;
            btnMedium.MouseLeave += btnMedium_MouseLeave;

            btnHard.MouseEnter += BtnHard_MouseEnter;
            btnHard.MouseLeave += BtnHard_MouseLeave;

        }


        private void BtnEasy_MouseEnter(object sender, EventArgs e)
        {
            // Show the label and set the text when the mouse enters the button
            lblGameDescription.Visible = true;
            lblGameDescription.Text = "**Easy Mode**: In this mode, the snake moves at a slower pace, making it easier for beginners to practice their control skills. The apples appear one at a time.";
        }

        private void BtnEasy_MouseLeave(object sender, EventArgs e)
        {
            // Hide the label when the mouse leaves the button
            lblGameDescription.Visible = false;
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            Easy form = new Easy();
            form.Show();
            this.Hide();
        }

        private void btnMedium_MouseEnter(object sender, EventArgs e)
        {
            // Show the label and set the text when the mouse enters the button
            lblGameDescription.Visible = true;
            lblGameDescription.Text = "**Medium Mode**: The snake moves at a moderate speed in this mode. Two apples appear at a time, making the game more challenging.";
        }

        private void btnMedium_MouseLeave(object sender, EventArgs e)
        {
            // Hide the label when the mouse leaves the button
            lblGameDescription.Visible = false;
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            Medium form = new Medium();
            form.Show();
            this.Hide();
        }

        private void BtnHard_MouseEnter(object sender, EventArgs e)
        {
            // Show the label and set the text when the mouse enters the button
            lblGameDescription.Visible = true;
            lblGameDescription.Text = "**Hard Mode**: This is the ultimate challenge! The snake moves very fast and three apples appear at a time. This mode is perfect for advanced players who want to test their skills.";
        }

        private void BtnHard_MouseLeave(object sender, EventArgs e)
        {
            // Hide the label when the mouse leaves the button
            lblGameDescription.Visible = false;
        }
        private void btnHard_Click(object sender, EventArgs e)
        {
            Hard form = new Hard();
            form.Show();
            this.Hide();
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
    }
}
