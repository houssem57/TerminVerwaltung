using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace LoginApp
{
    public partial class EmailForm : Form
    {
        public EmailForm()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Sending the email.
            //Now we must create a new Smtp client to send our email.

            //smtp.gmail.com // For Gmail
            //smtp.live.com // Windows live / Hotmail
            //smtp.mail.yahoo.com // Yahoo
            //smtp.aim.com // AIM
            //my.inbox.com // Inbox  password advpkjuvehomejjz
            try
            {

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("houssemfarid57@gmail.com");
                msg.To.Add(textBoxTo.Text);
                msg.Subject = textBoxSubject.Text;
                msg.Body = textBoxBody.Text;

                SmtpClient smt = new SmtpClient();
                smt.Host = "smtp.gmail.com";
                System.Net.NetworkCredential ntcd = new NetworkCredential();
                ntcd.UserName = "houssemfarid57@gmail.com";
                ntcd.Password = "advpkjuvehomejjz";
                smt.Credentials = ntcd;
                smt.EnableSsl = true;
                smt.Port = 587;
                smt.Send(msg);
                textBoxTo.Text = "";
                textBoxSubject.Text = "";
                textBoxBody.Text = "";

                MessageBox.Show("Your Mail is sended");
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            textBoxBody.SelectionFont = fontDialog1.Font;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            textBoxBody.SelectionColor = colorDialog1.Color;
        }

      
    }
}
