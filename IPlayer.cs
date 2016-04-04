using System;
using System.Collections.Generic;

namespace BlackJack3
{
    abstract class AbstractPlayer
    {
        public int Aggregate { get; set; }
        public int Sum { get; set; }
        public List<Card> Cards = new List<Card>();

        public void Clear()
        {
            Sum = 0;
            Cards.Clear();
        }
        public void TakeCards(Deck deck)
        {
            
            for (int i = 0; i < 2; i++)
            {
                Sum += deck.deck[0].Value;
                Cards.Add(deck.deck[0]);                
                deck.deck.Remove(deck.deck[0]);
            }          
        }

        public void ShowCards()
        {
            for (int i = 0; i < Cards.Count; i++)
            {
                Console.Write(Cards[i].Rank + Cards[i].Suit + "  \n");
            }
        }

    }
}