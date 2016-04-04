using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack3
{
    class Deck
    {
        public int Count { get; } = 54;

        public List<Card> deck = new List<Card>();


        public void Add(Card card)
        {
            deck.Add(card);
        }
               

        public void CreateDeck()
        {
            
            int suitsAmount = 4;
            int oneSuitCardsAmount = 13;
                                  
            for (int i = 0; i < suitsAmount; i++)
            {
                for (int j = 0; j < oneSuitCardsAmount; j++)
                {
                    deck.Add(new Card(ranks[j], suits[i], values[j]));
                }
            }
            
        }

        public void ShuffleTheDeck()
        {
            Random random = new Random();
            
            for (int i = 0; i < deck.Count; i++)
            {

                int r = i + (int)(random.NextDouble() * (deck.Count - i));
                Card card = deck[r];
                deck[r] = deck[i];
                deck[i] = card;
              
            }

        }

        public Deck()
        {
            CreateDeck();
        }
        
        public string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        public string[] suits = { "[S]", "[C]", "[H]", "[D]" };
        public int[] values = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };
        
    }
}