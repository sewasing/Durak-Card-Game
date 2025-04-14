// Group - 4
// Members - Samrat Jayanta Bhurtel, Chirayu Patel, Manansinh Vansia, Kultaran Singh and Niraj Bhandari
// Date - 2025/04/01
// Description - Player class representing a player in the Durak card game, with properties for name and hand of cards.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakCardGame
{
    public class Player
    {
        public string Name { get; }
        public List<Card> Hand { get; }

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }

        public void DrawCard(Card card)
        {
            if (card != null)
                Hand.Add(card);
        }

        public void RemoveCard(Card card) => Hand.Remove(card);
    }

}
