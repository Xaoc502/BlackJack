using System;
using System.Collections.Generic;

namespace BlackJack3
{
    static class GameConsole
    {
        public static Deck deck = new Deck();
        public static bool started = false;
        static Game game = new Game();
        static GameConsole()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            
        }
       
        public static void ShowTheDeck()
        {

            foreach (Card card in deck.deck)
            {
                Console.Write(card.Rank + card.Suit + "  ");
            }

        }

        public static void StartGame()
        {            
                                  
            while (true)
            {

                if (!started)
                {
                    Console.WriteLine(GameText.preGameOptions);
                    int command = Convert.ToInt32(Console.ReadLine());

                    if (command == 1)
                    {
                        deck.ShuffleTheDeck();
                    }
                    else if (command == 2)
                    {
                        ShowTheDeck();
                    }
                    else if (command == 3)
                    {
                        game.Start(deck);
                        
                        started = true;
                    }
                    else
                    {
                        Console.WriteLine(GameText.errorCommand);
                    }
                }
                else
                {
                    Console.WriteLine(GameText.gameOptions);
                    int command = Convert.ToInt32(Console.ReadLine());

                    if (command == 1)
                    {
                        game.Hit(deck);                        
                    }
                    else if (command == 2)
                    {
                        game.Count(deck);                        
                    }
                    else
                    {
                        Console.WriteLine(GameText.errorCommand);
                    }
                }

            }                                                    
                            
         }

        public static void Draw()
        {
            Console.WriteLine(GameText.draw);
        }

        public static void Lose()
        {
            Console.WriteLine(GameText.lose);
        }

        public static void Win()
        {
            Console.WriteLine(GameText.win);
        }

        public static void StartNextRound(Player player, Dealer dealer)
        {            
            Console.WriteLine("\n" + GameText.nextRound);
            Console.ReadKey();
            started = false;
            deck = new Deck();
            Console.Clear();
            Console.WriteLine(GameText.score, player.Aggregate, dealer.Aggregate);
        }
    }

    
}