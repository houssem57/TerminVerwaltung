using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace LoginApp
{
    public partial class UserControlRigester : UserControl
    {
        public string conString = @"Server=127.0.0.1;Database=login;User=root;Password=;";
        public UserControlRigester()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textUserName.Text = "";
            textPassword.Text = "";
            textPassword1.Text = "";
            textUserName.Focus();   
        }

        private void buttonRigester_Click(object sender, EventArgs e)
        {
            

            MySqlConnection conn = new MySqlConnection(conString);
            
                conn.Open();
                
           string query =   "SELECT * FROM new_login WHERE user_name = '"+textUserName.Text+"'; ";  
            MySqlDataAdapter data = new MySqlDataAdapter(query, conn);
            DataTable dataTable = new DataTable();
            data.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                MessageBox.Show("Username : " + textUserName.Text + " Already exist");
                textUserName.Text = "";
                textPassword.Text = "";
                textPassword1.Text = "";
                textUserName.Focus();
            }
            else if((textUserName.Text !="") && (textPassword.Text !="") && (textPassword1.Text !="") &&(textPassword.Text==textPassword1.Text) )
            {
                

                query = "INSERT INTO new_login(user_name, password, password1) VALUES (@username, @password, @password1)";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@username", textUserName.Text);
                command.Parameters.AddWithValue("@password", textPassword.Text);
                command.Parameters.AddWithValue("@password1", textPassword1.Text);
                command.ExecuteNonQuery();

                textUserName.Text = "";
                textPassword.Text = "";
                textPassword1.Text = "";
                textUserName.Focus();
                GetStarted getStarted = new GetStarted();
                getStarted.Show();

                MessageBox.Show("Jetzt können Sie sich anmelden", "Erfolgreich bestätigt",MessageBoxButtons.OK,MessageBoxIcon.Information);


            }
            



        }

        private void checkBoxPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPassword.Checked)
            {
                textPassword.UseSystemPasswordChar = false;
                textPassword1.UseSystemPasswordChar = false;
            }
            else 
            { 
                textPassword.UseSystemPasswordChar = true;
                textPassword1.UseSystemPasswordChar = true;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
