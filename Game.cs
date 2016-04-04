using System;

namespace BlackJack3
{
    class Game
    {
        
        public Player player = new Player();
        public Dealer dealer = new Dealer();
        

        public void Start(Deck deck)
        {
            player.TakeCards(deck);
            player.ShowCards();
            if (player.Sum == 22)
            {
                GameConsole.Win();
                player.Aggregate++;
                StartNextRound();
            }
        }

        public void Hit(Deck deck)
        {
            player.Hit(deck);
            player.ShowCards();
            if (player.Sum > 21)
            {
                GameConsole.Lose();
                dealer.Aggregate++;
                StartNextRound();
            }            
        }

        public void Count(Deck deck)
        {
            dealer.TakeCards(deck);
            dealer.ShowCards();
            if (player.Sum > dealer.Sum)
            {                
                GameConsole.Win();
                player.Aggregate++;
                StartNextRound();
            }
            else if (player.Sum < dealer.Sum)
            {                
                GameConsole.Lose();
                dealer.Aggregate++;
                StartNextRound();
            }
            else
            {                
                GameConsole.Draw();
                StartNextRound();
            }
        }

        public void StartNextRound()
        {            
            GameConsole.StartNextRound(player, dealer);
            player.Clear();
            dealer.Clear();
        }

    }
}