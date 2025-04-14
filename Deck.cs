// Group - 4
// Members - Samrat Jayanta Bhurtel, Chirayu Patel, Manansinh Vansia, Kultaran Singh and Niraj Bhandari
// Date - 2025/04/01
// Description - Deck class for the Durak card game, managing a deck of cards, shuffling, and drawing cards.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakCardGame
{
    public class Deck
    {
        private List<Card> cards;
        public Card TrumpCard { get; private set; }

        public Deck()
        {
            cards = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (int rank = 6; rank <= 14; rank++)
                    cards.Add(new Card(suit, rank));
            }

            Shuffle();
            TrumpCard = cards.Last();
            foreach (var card in cards)
                card.IsTrump = card.Suit == TrumpCard.Suit;
        }

        public void Shuffle() => cards = cards.OrderBy(_ => Guid.NewGuid()).ToList();
        public Card DrawCard() => cards.Count > 0 ? cards.RemoveLastAndReturn() : null;
        public int Count => cards.Count;
    }
    public static class ListExtensions
    {
        public static T RemoveLastAndReturn<T>(this List<T> list)
        {
            var item = list.Last();
            list.RemoveAt(list.Count - 1);
            return item;
        }
    }

}
