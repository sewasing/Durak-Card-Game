// Group - 4
// Members - Samrat Jayanta Bhurtel, Chirayu Patel, Manansinh Vansia, Kultaran Singh and Niraj Bhandari
// Date - 2025/04/01
// Description - Card class representing a playing card in the Durak card game, with properties for suit, rank, and image path.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakCardGame
{
    public enum Suit { Hearts, Diamonds, Clubs, Spades }
    public class Card
    {
        public Suit Suit { get; set; }
        public int Rank { get; set; } // 6-14 (where 14 is Ace)
        public bool IsTrump { get; set; }

        public Card(Suit suit, int rank)
        {
            Suit = suit;
            Rank = rank;
            IsTrump = false;
        }

        public string ImagePath
        {
            get
            {
                string suit = Suit.ToString().ToLower();
                string rankStr = Rank switch
                {
                    11 => "jack",
                    12 => "queen",
                    13 => "king",
                    14 => "ace",
                    _ => Rank.ToString()
                };

                return $"/Assets/Cards/{rankStr}_of_{suit}.png";
            }
        }


    }

}
