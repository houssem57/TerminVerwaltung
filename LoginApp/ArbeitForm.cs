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

namespace LoginApp
{
    public partial class ArbeitForm : Form
    {
        public ArbeitForm()
        {
            InitializeComponent();
            GetTermine();
        }

        public string conString = @"Server=127.0.0.1;Database=login;User=root;Password=;";
        private void GetTermine()
        {
            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                connection.Open();
                MySqlDataAdapter data = new MySqlDataAdapter("SELECT * FROM arbeit_termine ", connection);
                DataTable dataTable = new DataTable();
                data.Fill(dataTable);
                dataGridView1.DataSource = dataTable;


            }
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void buttonAbsagen_Click(object sender, EventArgs e)
        {
            EmailForm emailForm = new EmailForm();
            emailForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                connection.Open();

                string query = "INSERT INTO arbeit_termine(ansprechpartner, email, adresse, position, datum, zeit) VALUES (@ansprechpartner, @email, @adresse, @position, @datum, @zeit );";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ansprechpartner", txtAnsprechpartnerName.Text);
                command.Parameters.AddWithValue("@email", txtAnsprechpartnerEmail.Text);
                command.Parameters.AddWithValue("@adresse", txtAnsprechpartnerAdresse.Text);
                command.Parameters.AddWithValue("@position", txtPosition.Text);
                command.Parameters.AddWithValue("@datum", TerminDate.Text.ToString());
                command.Parameters.AddWithValue("@zeit", txtTerminZeit.Text);
                int rowsAffected = command.ExecuteNonQuery();
                txtAnsprechpartnerName.Text = "";
                txtAnsprechpartnerEmail.Text = "";
                txtAnsprechpartnerAdresse.Text = "";
                txtPosition.Text = "";
                txtTerminZeit.Text = "";
                txtAnsprechpartnerName.Focus();
                GetTermine();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                MySqlConnection connection = new MySqlConnection(conString);

                connection.Open();
                string update = "UPDATE arbeit_termine SET ansprechpartner =@ansprechpartner , email =@email, adresse =@adresse, position =@position, datum =@datum, zeit =@zeit WHERE ID = " + id + "; ";
                MySqlCommand command = new MySqlCommand(update, connection);
                command.Parameters.AddWithValue("@ansprechpartner", txtAnsprechpartnerName.Text);
                command.Parameters.AddWithValue("@email", txtAnsprechpartnerEmail.Text);
                command.Parameters.AddWithValue("@adresse", txtAnsprechpartnerAdresse.Text);
                command.Parameters.AddWithValue("@position", txtPosition.Text);
                command.Parameters.AddWithValue("@datum", TerminDate.Text.ToString());
                command.Parameters.AddWithValue("@zeit", txtTerminZeit.Text);

                int rowsAffected = command.ExecuteNonQuery();

                txtAnsprechpartnerName.Text = "";
                txtAnsprechpartnerEmail.Text = "";
                txtAnsprechpartnerAdresse.Text = "";
                txtPosition.Text = "";
                txtTerminZeit.Text = "";
                txtAnsprechpartnerName.Focus();


                GetTermine();
            }
           
        }

        private void aktualisierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];



                txtAnsprechpartnerName.Text = Convert.ToString(selectedRow.Cells["ansprechpartner"].Value);
                txtAnsprechpartnerEmail.Text = Convert.ToString(selectedRow.Cells["email"].Value);
                txtAnsprechpartnerAdresse.Text = Convert.ToString(selectedRow.Cells["adresse"].Value);
                txtPosition.Text = Convert.ToString(selectedRow.Cells["position"].Value);
                txtTerminZeit.Text = Convert.ToString(selectedRow.Cells["zeit"].Value);
            }
        }

        private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                connection.Open();

                string delete = "DELETE FROM arbeit_termine WHERE ID =" + selectedRow.Cells["ID"].Value + " ;";
                MySqlCommand command = new MySqlCommand(delete, connection);
                int rowsAffected = command.ExecuteNonQuery();
                GetTermine();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                connection.Open();

                string delete = "DELETE FROM arbeit_termine WHERE ID =" + selectedRow.Cells["ID"].Value + " ;";
                MySqlCommand command = new MySqlCommand(delete, connection);
                int rowsAffected = command.ExecuteNonQuery();
                GetTermine();

            }
        }

// 
        private void absagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailForm emailForm = new EmailForm();
            emailForm.Show();
        }
    }
}
