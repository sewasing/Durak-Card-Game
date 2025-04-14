// Group - 4
// Members - Samrat Jayanta Bhurtel, Chirayu Patel, Manansinh Vansia, Kultaran Singh and Niraj Bhandari
// Date - 2025/04/01
// Description - MainWindow class for the Durak card game, handling UI interactions and game state management.
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DurakCardGame
{
    public partial class MainWindow : Window
    {
        private Game game;
        private bool isPaused = false;

        public MainWindow()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void StartNewGame()
        {
            game = new Game();
            isPaused = false;
            UpdateUI();
            MessageBox.Show("New game started!");
        }

        private void UpdateUI()
        {
            if (game == null) return;

            TrumpCardText.Text = $"Trump: {game.TrumpCard.Rank} of {game.TrumpCard.Suit}";

            // Display player cards (face up)
            PlayerList.ItemsSource = null;
            PlayerList.ItemsSource = game.Human.Hand;

            // Display AI cards as back of card
            AIList.ItemsSource = null;
            AIList.ItemsSource = game.AI.Hand;
        }

        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            if (game == null)
            {
                MessageBox.Show("Start a new game first.");
                return;
            }

            if (isPaused)
            {
                MessageBox.Show("Game is paused.");
                return;
            }

            if (PlayerList.SelectedItem == null)
            {
                MessageBox.Show("Select a card to attack.");
                return;
            }

            // Get selected card object (not string!)
            Card selectedCard = PlayerList.SelectedItem as Card;

            if (selectedCard == null)
                return;

            // AI attempts to defend
            Card aiDefense = game.AI.ChooseDefenseCard(selectedCard);

            string msg;
            if (aiDefense != null)
            {
                game.AI.RemoveCard(aiDefense);
                msg = $"AI defends with {aiDefense}";
            }
            else
            {
                msg = "AI cannot defend!";
            }

            // Remove card from human
            game.Human.RemoveCard(selectedCard);
            game.RefillHands();
            UpdateUI();

            if (game.IsGameOver())
            {
                bool playerWon = game.Human.Hand.Count == 0;
                string winner = playerWon ? "You" : "AI";

                MessageBox.Show($"{winner} wins!");
            }
            else
            {
                MessageBox.Show(msg);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (game == null)
            {
                MessageBox.Show("Nothing to save.");
                return;
            }

            Logger.SaveGameToJson(game, "durak_save.json");
            MessageBox.Show("Game saved to durak_save.json!");
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            StartNewGame();
        }

        private void PauseGame_Click(object sender, RoutedEventArgs e)
        {
            if (game == null)
            {
                MessageBox.Show("No game is active.");
                return;
            }

            isPaused = !isPaused;
            MessageBox.Show(isPaused ? "Game paused." : "Game resumed.");
        }

        private void EndGame_Click(object sender, RoutedEventArgs e)
        {
            game = null;
            PlayerList.ItemsSource = null;
            AIList.ItemsSource = null;
            TrumpCardText.Text = "Trump:";
            MessageBox.Show("Game ended.");
        }
    }
}
