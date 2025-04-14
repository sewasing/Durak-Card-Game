// Group - 4
// Members - Samrat Jayanta Bhurtel, Chirayu Patel, Manansinh Vansia, Kultaran Singh and Niraj Bhandari
// Date - 2025/04/01
// Description - AIPlayer class for the Durak card game, implementing basic AI logic for choosing attack and defense cards.
using System;
using System.Collections.Generic;
using System.Linq;

namespace DurakCardGame
{
    public class AIPlayer : Player
    {
        public AIPlayer(string name) : base(name) { }

        public Card ChooseAttackCard()
        {
            // Choose weakest non-trump card first, then trump
            return Hand
                .OrderBy(c => c.IsTrump) // false (non-trump) first
                .ThenBy(c => c.Rank)
                .FirstOrDefault();
        }

    public Card ChooseDefenseCard(Card attackCard)
    {
          return Hand
                .Where(c =>
                    (c.Suit == attackCard.Suit && c.Rank > attackCard.Rank) || // same suit, higher rank
                    (c.IsTrump && !attackCard.IsTrump) // trump beats non-trump
                )
                .OrderBy(c => c.IsTrump) // prefer non-trump defense first
                .ThenBy(c => c.Rank)
                .FirstOrDefault();
        }
    }
}
