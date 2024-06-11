using System;
using System.Windows.Forms;

namespace TICTACLOG
{
    public partial class Logins : Form
    {
        private Administrator _admin;

        public Logins(Administrator admin)
        {
            InitializeComponent();
            _admin = admin;
            textBox2.PasswordChar = '*';
            textBox4.PasswordChar = '*';
        }

        private void Logins_Load(object sender, EventArgs e)
        {
            // Initialize components or load data if necessary
        }

        private void btnLoginAsAdmin_Click(object sender, EventArgs e)
        {
            string adminId = textBox1.Text;
            string password = textBox2.Text;

            if (_admin.VerifyLogin(adminId, password))
            {
                MessageBox.Show("Admin login successful!");
                Adminis adminForm = new Adminis(_admin);
                adminForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid admin credentials!");
            }
        }

        private void btnLoginAsPlayer_Click(object sender, EventArgs e)
        {
            string playerId = textBox3.Text;
            string password = textBox4.Text;

            Player player = null;
            foreach (var p in _admin.GetPlayers())
            {
                if (p != null && p.VerifyLogin(playerId, password))
                {
                    player = p;
                    break;
                }
            }

            if (player != null)
            {
                MessageBox.Show("Player login successful!");
                Form1 gameForm = new Form1(_admin);
                gameForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid player credentials!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
