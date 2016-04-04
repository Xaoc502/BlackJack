namespace BlackJack3
{
    class Player : AbstractPlayer
    {        
        public void Hit(Deck deck)
        {
            Sum += deck.deck[0].Value;
            Cards.Add(deck.deck[0]);
            deck.deck.Remove(deck.deck[0]);                        
        }
    }
}