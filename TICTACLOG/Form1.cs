using System;
using System.Windows.Forms;

namespace TICTACLOG
{
    public partial class Form1 : Form
    {
        private char currentPlayer;
        private int xWins, oWins;
        private Administrator _admin;

        public Form1(Administrator admin)
        {
            InitializeComponent();
            currentPlayer = 'X';
            xWins = 0;
            oWins = 0;
            _admin = admin;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateWinCountLabels();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null && string.IsNullOrEmpty(clickedButton.Text))
            {
                clickedButton.Text = currentPlayer.ToString();
                if (CheckForWinner())
                {
                    if (currentPlayer == 'X')
                    {
                        xWins++;
                        MessageBox.Show("X Wins!");
                    }
                    else
                    {
                        oWins++;
                        MessageBox.Show("O Wins!");
                    }
                    UpdateWinCountLabels();
                    ResetGame();
                }
                else if (IsBoardFull())
                {
                    MessageBox.Show("It's a draw!");
                    ResetGame();
                }
                else
                {
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            ResetGame();
            xWins = 0;
            oWins = 0;
            UpdateWinCountLabels();
        }

        private void ResetGame()
        {
            foreach (Control control in Controls)
            {
                if (control is Button && control.Name.StartsWith("button"))
                {
                    ((Button)control).Text = string.Empty;
                }
            }
            currentPlayer = 'X';
        }

        private bool CheckForWinner()
        {
            string[,] board = new string[3, 3];

            for (int i = 0; i < 9; i++)
            {
                board[i / 3, i % 3] = Controls["button" + i].Text;
            }

            // Check rows, columns, and diagonals
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == currentPlayer.ToString() && board[i, 1] == currentPlayer.ToString() && board[i, 2] == currentPlayer.ToString())
                    return true;
                if (board[0, i] == currentPlayer.ToString() && board[1, i] == currentPlayer.ToString() && board[2, i] == currentPlayer.ToString())
                    return true;
            }

            if (board[0, 0] == currentPlayer.ToString() && board[1, 1] == currentPlayer.ToString() && board[2, 2] == currentPlayer.ToString())
                return true;
            if (board[0, 2] == currentPlayer.ToString() && board[1, 1] == currentPlayer.ToString() && board[2, 0] == currentPlayer.ToString())
                return true;

            return false;
        }

        private bool IsBoardFull()
        {
            foreach (Control control in Controls)
            {
                if (control is Button && control.Name.StartsWith("button") && string.IsNullOrEmpty(control.Text))
                {
                    return false;
                }
            }
            return true;
        }

        private void UpdateWinCountLabels()
        {
            xWinsLabel.Text = "X Wins: " + xWins;
            oWinsLabel.Text = "O Wins: " + oWins;
        }
        private void logoutButton_Click(object sender, EventArgs e)
        {
            Logins login = new Logins(_admin); 
            login.Show();   
        }
    }
}
