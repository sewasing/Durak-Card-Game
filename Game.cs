// Group - 4
// Members - Samrat Jayanta Bhurtel, Chirayu Patel, Manansinh Vansia, Kultaran Singh and Niraj Bhandari
// Date - 2025/04/01
// Description - Game class for the Durak card game, managing the game state, player turns, and card dealing.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakCardGame
{
    public class Game
    {
        public Deck Deck { get; }
        public Player Human { get; }
        public AIPlayer AI { get; }
        public Card TrumpCard => Deck.TrumpCard;

        public Game()
        {
            Deck = new Deck();
            Human = new Player("You");
            AI = new AIPlayer("Bot");

            DealInitialCards();
        }

        private void DealInitialCards()
        {
            for (int i = 0; i < 6; i++)
            {
                Human.DrawCard(Deck.DrawCard());
                AI.DrawCard(Deck.DrawCard());
            }
        }

        public void RefillHands()
        {
            while (Human.Hand.Count < 6) Human.DrawCard(Deck.DrawCard());
            while (AI.Hand.Count < 6) AI.DrawCard(Deck.DrawCard());
        }

        public bool IsGameOver() => Human.Hand.Count == 0 || AI.Hand.Count == 0;
    }

}
