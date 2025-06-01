using Microsoft.Maui.Controls;
using System;

namespace JogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        private string currentPlayer = "X";
        private Button[,] buttons;

        public MainPage()
        {
            InitializeComponent();
            buttons = new Button[3, 3]
            {
                { btn00, btn01, btn02 },
                { btn10, btn11, btn12 },
                { btn20, btn21, btn22 }
            };
            ResetBoard();
        }

        private void OnCellClicked(object sender, EventArgs e)
        {
            if (sender is Button btn && string.IsNullOrEmpty(btn.Text))
            {
                btn.Text = currentPlayer;
                btn.IsEnabled = false;

                if (CheckVictory(currentPlayer))
                {
                    statusLabel.Text = $"Jogador {currentPlayer} venceu!";
                    DisableAllButtons();
                }
                else if (IsDraw())
                {
                    statusLabel.Text = "Empate!";
                }
                else
                {
                    currentPlayer = currentPlayer == "X" ? "O" : "X";
                    statusLabel.Text = $"Vez do Jogador {currentPlayer}";
                }
            }
        }

        private void OnRestartClicked(object sender, EventArgs e)
        {
            ResetBoard();
        }

        private void ResetBoard()
        {
            foreach (var btn in buttons)
            {
                btn.Text = "";
                btn.IsEnabled = true;
            }
            currentPlayer = "X";
            statusLabel.Text = "Jogador X começa";
        }

        private void DisableAllButtons()
        {
            foreach (var btn in buttons)
            {
                btn.IsEnabled = false;
            }
        }

        private bool CheckVictory(string player)
        {
           
            for (int i = 0; i < 3; i++)
                if (buttons[i, 0].Text == player &&
                    buttons[i, 1].Text == player &&
                    buttons[i, 2].Text == player)
                    return true;

            
            for (int j = 0; j < 3; j++)
                if (buttons[0, j].Text == player &&
                    buttons[1, j].Text == player &&
                    buttons[2, j].Text == player)
                    return true;

            
            if (buttons[0, 0].Text == player &&
                buttons[1, 1].Text == player &&
                buttons[2, 2].Text == player)
                return true;

            if (buttons[0, 2].Text == player &&
                buttons[1, 1].Text == player &&
                buttons[2, 0].Text == player)
                return true;

            return false;
        }

        private bool IsDraw()
        {
            foreach (var btn in buttons)
            {
                if (string.IsNullOrEmpty(btn.Text))
                    return false;
            }
            return true;
        }
    }
}
