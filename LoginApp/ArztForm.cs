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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace LoginApp
{
    public partial class ArztForm : Form
    {

        public ArztForm()
        {
            InitializeComponent();
            txtArztName.Focus();
            GetTermine();
            
        }

        public string conString = @"Server=127.0.0.1;Database=login;User=root;Password=;";
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void GetTermine()
        {
            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                connection.Open();
                MySqlDataAdapter data = new MySqlDataAdapter("SELECT * FROM arzt_termine ", connection);
                DataTable dataTable = new DataTable();
                data.Fill(dataTable);
                dataGridView1.DataSource = dataTable;


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                connection.Open();

                string query = "INSERT INTO arzt_termine(arztName, email, adresse, spezialitat, datum, zeit) VALUES (@arztname,@email ,@adresse ,@spezialitat ,@datum ,@zeit );";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@arztname", txtArztName.Text);
                command.Parameters.AddWithValue("@email", txtArztEmail.Text);
                command.Parameters.AddWithValue("@adresse", txtArztAdresse.Text);
                command.Parameters.AddWithValue("@spezialitat", txtArztSpezialitat.Text);
                command.Parameters.AddWithValue("@datum", TerminDate.Text.ToString());
                command.Parameters.AddWithValue("@zeit", txtTerminZeit.Text);
                int rowsAffected = command.ExecuteNonQuery();
                txtArztName.Text = "";
                txtArztEmail.Text = "";
                txtArztAdresse.Text = "";
                txtArztSpezialitat.Text = "";
                txtTerminZeit.Text = "";
                txtArztName.Focus();
                GetTermine();
            }
        }

        private void buttonAbsage_Click(object sender, EventArgs e)
        {
            EmailForm form = new EmailForm();
            form.ShowDialog();
        }

        private void aktualisierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                
                
                txtArztName.Text = Convert.ToString(selectedRow.Cells["arztName"].Value);
                txtArztEmail.Text = Convert.ToString(selectedRow.Cells["email"].Value);
                txtArztAdresse.Text = Convert.ToString(selectedRow.Cells["adresse"].Value);
                txtArztSpezialitat.Text = Convert.ToString(selectedRow.Cells["spezialitat"].Value);
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
                string update = "UPDATE arzt_termine SET arztName =@arztName , email =@email, adresse =@adresse, spezialitat =@spezialitat, datum =@datum, zeit =@zeit WHERE ID = " + id + "; ";
                MySqlCommand command = new MySqlCommand(update, connection);
                command.Parameters.AddWithValue("@arztName", txtArztName.Text);
                command.Parameters.AddWithValue("@email", txtArztEmail.Text);
                command.Parameters.AddWithValue("@adresse", txtArztAdresse.Text);
                command.Parameters.AddWithValue("@spezialitat", txtArztSpezialitat.Text);
                command.Parameters.AddWithValue("@datum", TerminDate.Text.ToString());
                command.Parameters.AddWithValue("@zeit", txtTerminZeit.Text);

                int rowsAffected = command.ExecuteNonQuery();

                txtArztName.Text = "";
                txtArztEmail.Text = "";
                txtArztAdresse.Text = "";
                txtArztSpezialitat.Text = "";
                txtTerminZeit.Text = "";
                txtArztName.Focus();    

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

                string delete = "DELETE FROM arzt_termine WHERE ID =" + selectedRow.Cells["ID"].Value + " ;";
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

                string delete = "DELETE FROM arzt_termine WHERE ID =" + selectedRow.Cells["ID"].Value + " ;";
                MySqlCommand command = new MySqlCommand(delete, connection);
                int rowsAffected = command.ExecuteNonQuery();
                GetTermine();

            }

        }

        private void absagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailForm emailForm = new EmailForm();
            emailForm.ShowDialog();
        }
    }
    
}
