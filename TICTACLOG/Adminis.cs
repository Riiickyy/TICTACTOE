using System;
using System.Windows.Forms;

namespace TICTACLOG
{
    public partial class Adminis : Form
    {
        private Administrator _admin;

        public Adminis(Administrator admin)
        {
            InitializeComponent();
            this._admin = admin;
            textBox3.PasswordChar = '*';
            textBox5.PasswordChar = '*';
        }

        private void Adminis_Load(object sender, EventArgs e)
        {
            // Load event logic (if any)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string playerId = textBox2.Text;
            string playerPassword = textBox3.Text;

            if (string.IsNullOrEmpty(playerId) || string.IsNullOrEmpty(playerPassword))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            Player newPlayer = _admin.CreatePlayer(playerId, playerPassword);
            if (newPlayer != null)
            {
                MessageBox.Show("Player created successfully!");
              
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string playerId = textBox4.Text;
            string newPassword = textBox5.Text;

            if (string.IsNullOrEmpty(playerId) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Please enter Player ID and new password.");
                return;
            }

           _admin.UpdatePlayerPassword(playerId, newPassword);
          
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           Logins login = new Logins(_admin);
            login.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
