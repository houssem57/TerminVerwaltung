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
    public partial class GetStarted : Form
    {
        public GetStarted()
        {
            InitializeComponent();
        }

        public void ShowForm(UserControl form)
        {
            try
            {
                form.Dock = DockStyle.Fill;
                form.Show();
                panel1.Controls.Add(form);
                form.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserControlLogin form = new UserControlLogin();
            ShowForm(form);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserControlRigester form = new UserControlRigester();
            ShowForm(form);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserControlAbout userControlAbout = new UserControlAbout();
            ShowForm(userControlAbout);
        }
    }
}
