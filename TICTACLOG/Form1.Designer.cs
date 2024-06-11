using System;
using System.Windows.Forms;

namespace TICTACLOG
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Button[] buttons;
        private Button restartButton;
        private Button logoutButton;
        private Label xWinsLabel;
        private Label oWinsLabel;

        // Cleanup resources
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Initialize Buttons
            buttons = new Button[9];
            for (int i = 0; i < 9; i++)
            {
                buttons[i] = new Button();
                buttons[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
                buttons[i].Location = new System.Drawing.Point((i % 3) * 100, (i / 3) * 100);
                buttons[i].Name = "button" + i;
                buttons[i].Size = new System.Drawing.Size(100, 100);
                buttons[i].TabIndex = i;
                buttons[i].UseVisualStyleBackColor = true;
                buttons[i].Click += new System.EventHandler(this.button_Click);
                this.Controls.Add(buttons[i]);
            }

            // Restart Button
            restartButton = new Button();
            restartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            restartButton.Location = new System.Drawing.Point(100, 310);
            restartButton.Name = "restartButton";
            restartButton.Size = new System.Drawing.Size(200, 50);
            restartButton.TabIndex = 9;
            restartButton.Text = "Restart Game";
            restartButton.UseVisualStyleBackColor = true;
            restartButton.Click += new System.EventHandler(this.restartButton_Click);
            this.Controls.Add(restartButton);

            // Logout Button
            logoutButton = new Button();
            logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            logoutButton.Location = new System.Drawing.Point(310, 310);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new System.Drawing.Size(200, 50);
            logoutButton.TabIndex = 10;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            this.Controls.Add(logoutButton);

            // Labels for win count
            xWinsLabel = new Label();
            xWinsLabel.Location = new System.Drawing.Point(10, 380);
            xWinsLabel.Name = "xWinsLabel";
            xWinsLabel.Size = new System.Drawing.Size(100, 30);
            xWinsLabel.TabIndex = 11;
            xWinsLabel.Text = "X Wins: 0";
            this.Controls.Add(xWinsLabel);

            oWinsLabel = new Label();
            oWinsLabel.Location = new System.Drawing.Point(260, 380);
            oWinsLabel.Name = "oWinsLabel";
            oWinsLabel.Size = new System.Drawing.Size(100, 30);
            oWinsLabel.TabIndex = 12;
            oWinsLabel.Text = "O Wins: 0";
            this.Controls.Add(oWinsLabel);

            // Form Settings
            this.ClientSize = new System.Drawing.Size(520, 421);
            this.Name = "Form1";
            this.Text = "Tic Tac Toe";
            this.ResumeLayout(false);
        }
    }
}
