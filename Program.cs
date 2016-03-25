using System;
using System.Collections.Generic;

namespace BlackJack2
{
    class Program
    {
        public static bool started = false;
        public static int aggregateComputer = 0;
        public static int aggregatePlayer = 0;
        public static Deck newDeck = new Deck();
        public static List<KeyValuePair<string, int>> deck = newDeck.CreateTheDeck();

        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Green;
                        
            Player player = new Player();
            Dealer dealer = new Dealer();
                        
            for (;;)
            {

                if (!started)
                {

                    Console.WriteLine();
                    Console.WriteLine("* To shuffle the deck type - shuffle");
                    Console.WriteLine("* To show the deck type - show");
                    Console.WriteLine("* To start the game type - start");
                    string command = Console.ReadLine();
                    switch (command)
                    {
                        case "shuffle":
                            deck = newDeck.ShuffleTheDeck(deck);
                            break;
                        case "show":
                            newDeck.ShowDeck(deck);
                            break;
                        case "start":
                            player.Start(deck);
                            started = true;
                            break;
                        default:
                            Console.WriteLine("You have entered an incorrect command!");
                            break;
                    }
                }
                else
                {

                    Console.WriteLine("* To take another card type - hit");
                    Console.WriteLine("* To take no more cards type - stand");
                    string command = Console.ReadLine();
                    switch (command)
                    {
                        case "hit":
                            player.Hit(deck);
                            break;
                        case "stand":
                            dealer.TakeCards(deck);
                            new GameRules().Calculate(player.sumPlayer, dealer.sumComputer);
                            break;
                        default:
                            Console.WriteLine("You have entered an incorrect command!");
                            break;
                    }
                }
            }                   
         }
    }
    

    public class Deck
    {
        //********************************** Shuffle the deck *****************************
        public List<KeyValuePair<string, int>> ShuffleTheDeck(List<KeyValuePair<string, int>> deck)
        {
            var randomDeck = new List<KeyValuePair<string, int>>();
            Random rnd = new Random();
            randomDeck.Add(deck[rnd.Next(0, deck.Count)]);
            int firstAdd = 1;
            for (int i = 0; i < deck.Count - firstAdd; i++)
            {
            again:
                int checker = rnd.Next(0, deck.Count);

                for (int j = 0; j < randomDeck.Count; j++)
                {

                    if (randomDeck[j].Equals(deck[checker]))
                    {
                        goto again;
                    }

                }

                randomDeck.Add(deck[checker]);
            }
            return randomDeck;
        }
        //********************************** Show the deck **********************************
        public void ShowDeck(List<KeyValuePair<string, int>> createTheDeck)
        {
            for (int i = 0; i < createTheDeck.Count; i++)
            {
                Console.Write(createTheDeck[i].Key + " ");
            }
        }
        //*********************************** Create new deck *******************************      
        public List<KeyValuePair<string, int>> CreateTheDeck()
        {
            var List = new List<KeyValuePair<string, int>>();

            Create("[S]", List);
            Create("[H]", List);
            Create("[D]", List);
            Create("[C]", List);

            return List;
        }

        public void Create(string suit, List<KeyValuePair<string, int>> List)
        {
            int cardValueStart = 2;
            
            for (int i = 0; i < 9; i++)
            {
                List.Add(new KeyValuePair<string, int>(Convert.ToString(i + cardValueStart) + suit, i + cardValueStart));
            }
            List.Add(new KeyValuePair<string, int>("Jack" + suit, 10));
            List.Add(new KeyValuePair<string, int>("Queen" + suit, 10));
            List.Add(new KeyValuePair<string, int>("King" + suit, 10));
            List.Add(new KeyValuePair<string, int>("Ace" + suit, 11));
        }
    }

    public class Player
    {
        public int sumPlayer = 0;
        public List<KeyValuePair<string, int>> Start(List<KeyValuePair<string, int>> deck)
        {
            
            for (int i = 0; i < 2; i++)
            {
                Console.Write(deck[0].Key + " ");
                sumPlayer += deck[0].Value;
                deck.Remove(deck[0]);
            }
            if (sumPlayer == 22)
            {
                Console.WriteLine("You Won!!!");
                Program.aggregatePlayer++;
            }
            Console.WriteLine();

            return deck;

        }

        public void Hit(List<KeyValuePair<string, int>> deck)
        {
            
            Console.WriteLine(deck[0].Key);
           
                sumPlayer += deck[0].Value;
                deck.Remove(deck[0]);

            if (sumPlayer > 21)
            {
                Console.WriteLine("You lose.");
                Program.aggregateComputer ++;
                
            }

        }

    }

    public class Dealer
    {
        public int sumComputer = 0;
        public void TakeCards(List<KeyValuePair<string, int>> deck)
        {
           
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(deck[0].Key);
                sumComputer += deck[0].Value;
                deck.Remove(deck[0]);
            }
                        
        }
    }

    public class GameRules
    {
        public void Calculate(int sumPlayer, int sumComputer)
        {
            if (sumPlayer > sumComputer)
            {
                Console.WriteLine("You Won!!!");
                Program.aggregatePlayer++;
                new Clear().StartNewRound();

            }

            else if (sumPlayer < sumComputer)
            {
                Console.WriteLine("Computer Won.");
                Program.aggregateComputer++;
                new Clear().StartNewRound();
            }

            else
            {
                Console.WriteLine("Draw.");
                new Clear().StartNewRound();
            }
        }
    }

    public class Clear
    {
        public void StartNewRound()
        {
            
            Console.WriteLine();
            Console.WriteLine("Press any key for starting the new round.");
            Console.ReadKey();
            Program.started = false;
            
            Console.Clear();
            Program.deck = Program.newDeck.CreateTheDeck();
            Console.WriteLine("TOTAL SCORE - Player {0} : {1} Computer", Program.aggregatePlayer, Program.aggregateComputer);
            Console.WriteLine();
        }
    }
    
}
