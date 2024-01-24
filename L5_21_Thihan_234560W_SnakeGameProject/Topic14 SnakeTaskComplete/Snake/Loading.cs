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
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            loadingBar.Increment(2);
            if (loadingBar.Value == 100)
            {
                timer1.Enabled = false;
                GameDescription form = new GameDescription();
                form.Show();
                this.Hide();
            }
            else
            {
                loadingmsg.Text = "loading , are you ready?";
            }
        }
    }
}
