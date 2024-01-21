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
    public partial class FamilieForm : Form
    {
        public FamilieForm()
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
                MySqlDataAdapter data = new MySqlDataAdapter("SELECT * FROM familie_termine ", connection);
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

        private void buttonAbsage_Click(object sender, EventArgs e)
        {
            EmailForm emailForm = new EmailForm();
            emailForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                connection.Open();

                string query = "INSERT INTO familie_termine(name, email, adresse, datum, zeit) VALUES (@name,@email ,@adresse ,@datum ,@zeit );";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("name", txtName.Text);
                command.Parameters.AddWithValue("@email", txtEmail.Text);
                command.Parameters.AddWithValue("@adresse", txtAdresse.Text);               
                command.Parameters.AddWithValue("@datum", TerminDate.Text.ToString());
                command.Parameters.AddWithValue("@zeit", txtTerminZeit.Text);
                int rowsAffected = command.ExecuteNonQuery();

                txtName.Text = "";
                txtEmail.Text = "";
                txtAdresse.Text = "";               
                txtTerminZeit.Text = "";
                txtName.Focus();
                GetTermine();
            }
        }

        private void aktualisierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];



                txtName.Text = Convert.ToString(selectedRow.Cells["name"].Value);
                txtEmail.Text = Convert.ToString(selectedRow.Cells["email"].Value);
                txtAdresse.Text = Convert.ToString(selectedRow.Cells["adresse"].Value);               
                txtTerminZeit.Text = Convert.ToString(selectedRow.Cells["zeit"].Value);
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
                string update = "UPDATE familie_termine SET name =@name , email =@email, adresse =@adresse,  datum =@datum, zeit =@zeit WHERE ID = " + id + "; ";
                MySqlCommand command = new MySqlCommand(update, connection);
                command.Parameters.AddWithValue("@name", txtName.Text);
                command.Parameters.AddWithValue("@email", txtEmail.Text);
                command.Parameters.AddWithValue("@adresse", txtAdresse.Text);               
                command.Parameters.AddWithValue("@datum", TerminDate.Text.ToString());
                command.Parameters.AddWithValue("@zeit", txtTerminZeit.Text);

                int rowsAffected = command.ExecuteNonQuery();

                txtName.Text = "";
                txtEmail.Text = "";
                txtAdresse.Text = "";
                txtTerminZeit.Text = "";

                GetTermine();
            }
        }

        private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                connection.Open();

                string delete = "DELETE FROM familie_termine WHERE ID =" + selectedRow.Cells["ID"].Value + " ;";
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

                string delete = "DELETE FROM familie_termine WHERE ID =" + selectedRow.Cells["ID"].Value + " ;";
                MySqlCommand command = new MySqlCommand(delete, connection);
                int rowsAffected = command.ExecuteNonQuery();
                GetTermine();

            }
        }

        private void absagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailForm emailForm = new EmailForm();
            emailForm.Show();
        }
    }
}
