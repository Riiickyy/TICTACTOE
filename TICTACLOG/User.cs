using System;
using System.Windows.Forms;

namespace TICTACLOG
{
    public abstract class User
    {
        protected string user_id;
        protected string user_password;

        public User(string id, string pass)
        {
            this.user_id = id;
            this.user_password = pass;
        }

        public bool VerifyLogin(string id, string pass)
        {
            return id.Equals(this.user_id) && pass.Equals(this.user_password);
        }

        public abstract void UpdatePassword(string newPassword);

        public string GetPassword()
        {
            return this.user_password;
        }

        public void SetPassword(string newPassword)
        {
            this.user_password = newPassword;
        }
    }

    public class Administrator : User
    {
        private Player[] players;
        private int playerCount;
        private const int maxPlayers = 10;

        public Administrator(string id, string pass) : base(id, pass)
        {
            this.players = new Player[maxPlayers];
            this.playerCount = 0;
        }

        public override void UpdatePassword(string newPassword)
        {
            this.SetPassword(newPassword);
        }

        public Player CreatePlayer(string playerId, string playerPass)
        {
            if (playerCount < maxPlayers)
            {
                Player newPlayer = new Player(playerId, playerPass);
                players[playerCount] = newPlayer;
                playerCount++;
                return newPlayer;
            }
            else
            {
                MessageBox.Show("Cannot add more players. Maximum limit reached.");
                return null;
            }
        }

        public void UpdatePlayerPassword(string playerId, string newPassword)
        {
            for (int i = 0; i < playerCount; i++)
            {
                if (players[i] != null && players[i].VerifyLogin(playerId, players[i].GetPassword()))
                {
                    players[i].UpdatePassword(newPassword);
                    MessageBox.Show("Player password updated successfully");
                    return;
                }
            }
            MessageBox.Show("Player not found.");
        }

        public Player[] GetPlayers()
        {
            Player[] currentPlayers = new Player[playerCount];
            Array.Copy(players, currentPlayers, playerCount);
            return currentPlayers;
        }
    }

    public class Player : User
    {
        public Player(string id, string pass) : base(id, pass)
        {
        }

        public override void UpdatePassword(string newPassword)
        {
            this.SetPassword(newPassword);
        }
    }
}
