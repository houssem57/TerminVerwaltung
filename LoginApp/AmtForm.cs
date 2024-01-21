using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LoginApp
{
    public partial class AmtForm : Form
    {
        public AmtForm()
        {
            InitializeComponent();
            GetTermine();
        }
        //Datenbank Verbindung
        public string conString = @"Server=127.0.0.1;Database=login;User=root;Password=;";

        //Termine von datenbank lesen
        private void GetTermine()
        {
            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                connection.Open();
                MySqlDataAdapter data = new MySqlDataAdapter("SELECT * FROM amt_termine ", connection);
                DataTable dataTable = new DataTable();
                data.Fill(dataTable);
                dataGridView1.DataSource = dataTable;


            }
        }


        //zurück zu Home seite
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }


        // zu email form gehen
        private void buttonAbsagen_Click(object sender, EventArgs e)
        {
            EmailForm emailForm = new EmailForm();
            emailForm.Show();
        }


        // neue termin einfugen
        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                connection.Open();

                string query = "INSERT INTO amt_termine(sachbearbeiter_Name, email, adresse, datum, zeit) VALUES (@name,@email ,@adresse ,@datum ,@zeit );";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("name", txtSachName.Text);
                command.Parameters.AddWithValue("@email", txtSachEmail.Text);
                command.Parameters.AddWithValue("@adresse", txtSachAdresse.Text);
                command.Parameters.AddWithValue("@datum", TerminDate.Text.ToString());
                command.Parameters.AddWithValue("@zeit", txtTerminZeit.Text);
                int rowsAffected = command.ExecuteNonQuery();

                txtSachName.Text = "";
                txtSachEmail.Text = "";
                txtSachAdresse.Text = "";
                txtTerminZeit.Text = "";
                txtSachName.Focus();
                GetTermine();
            }
        }

        //Zeile wählen umzu aktualisieren
        private void aktualisierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];



                txtSachName.Text = Convert.ToString(selectedRow.Cells["sachbearbeiter_Name"].Value);
                txtSachEmail.Text = Convert.ToString(selectedRow.Cells["email"].Value);
                txtSachAdresse.Text = Convert.ToString(selectedRow.Cells["adresse"].Value);
                txtTerminZeit.Text = Convert.ToString(selectedRow.Cells["zeit"].Value);
            }
        }

        // termin aktualisieren
        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                MySqlConnection connection = new MySqlConnection(conString);

                connection.Open();
                string update = "UPDATE amt_termine SET sachbearbeiter_Name =@name , email =@email, adresse =@adresse,  datum =@datum, zeit =@zeit WHERE ID = " + id + "; ";
                MySqlCommand command = new MySqlCommand(update, connection);
                command.Parameters.AddWithValue("@name", txtSachName.Text);
                command.Parameters.AddWithValue("@email", txtSachEmail.Text);
                command.Parameters.AddWithValue("@adresse", txtSachAdresse.Text);
                command.Parameters.AddWithValue("@datum", TerminDate.Text.ToString());
                command.Parameters.AddWithValue("@zeit", txtTerminZeit.Text);

                int rowsAffected = command.ExecuteNonQuery();

                txtSachName.Text = "";
                txtSachEmail.Text = "";
                txtSachAdresse.Text = "";
                txtTerminZeit.Text = "";

                GetTermine();
            }
        }

        //Zeile mit StripMenu löchen
        private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                connection.Open();

                string delete = "DELETE FROM amt_termine WHERE ID =" + selectedRow.Cells["ID"].Value + " ;";
                MySqlCommand command = new MySqlCommand(delete, connection);
                int rowsAffected = command.ExecuteNonQuery();
                GetTermine();

            }
        }

        // Zeile mit Button löchen
        private void button4_Click(object sender, EventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                connection.Open();

                string delete = "DELETE FROM amt_termine WHERE ID =" + selectedRow.Cells["ID"].Value + " ;";
                MySqlCommand command = new MySqlCommand(delete, connection);
                int rowsAffected = command.ExecuteNonQuery();
                GetTermine();

            }
        }

        // mit StripMenu zu email Form gehen
        private void absagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailForm emailForm = new EmailForm();
            emailForm.Show();
        }
    }
}
