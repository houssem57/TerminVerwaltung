using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace LoginApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string conString = @"Server=127.0.0.1;Database=login;User=root;Password=;";
        private void button2_Click(object sender, EventArgs e)
        {
            string userName, password;
            userName = txt_User.Text;
            password = txt_Password.Text;




            using (MySqlConnection conn = new MySqlConnection(conString))
            {
                string query = "SELECT * FROM new_login WHERE user_name= '" + txt_User.Text + "' AND password = '" + txt_Password.Text + "' ;";
                conn.Open();
                MySqlDataAdapter data = new MySqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                data.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    userName = txt_User.Text;
                    password = txt_Password.Text;

                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Login Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_User.Clear();
                    txt_Password.Clear();
                    txt_User.Focus();
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_User.Text = "";
            txt_Password.Text = "";
            txt_User.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_Password.UseSystemPasswordChar = false;
            }
            else { txt_Password.UseSystemPasswordChar = true; }
        }
    }
}
