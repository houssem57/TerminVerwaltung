using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

       

        private void ButtonHover(object sender, EventArgs e)
        {
            

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonLeave(object sender, EventArgs e)
        {
            
        }

        private void buttonArzt_Click(object sender, EventArgs e)
        {
            ArztForm arztForm = new ArztForm();
            this.Hide();
            arztForm.Show();
        }

        private void buttonFamilie_Click(object sender, EventArgs e)
        {
            FamilieForm familieForm = new FamilieForm();
            this.Hide();
            familieForm.Show();
        }

        private void buttonArbeit_Click(object sender, EventArgs e)
        {
            ArbeitForm arbeitForm = new ArbeitForm();
            this.Hide();
            arbeitForm.Show();
        }

        private void buttonAmt_Click(object sender, EventArgs e)
        {
            AmtForm amtForm = new AmtForm();
            this.Hide();
            amtForm.Show();
        }
    }
}
