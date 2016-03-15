using System;
using System.Collections.Generic;


//Заказчиком была заявлена следующая функциональность:
//1. При запуске, программа должна уметь сформировать
//колоду из карт(от 2-х до туза) всех мастей.
//До начала раунда:
//2. При соответствующей команде в консоле, игра должна
//показывать все карты в колоде.
//3. При соответствующей команде, игра должна перемешивать
//колоду в случайном порядке.
//Во время раунда:
//4. При соответствующей команде, игра должна раздавать
//игроку 2 верхних карты в колоде.y
//5. Соответствующей командой игрок может потребовать
//еще карту.Если значение карт игрока превысило 21,
//то он проиграл.
//6. Соответствующей командой игрок может отказаться от
//карты.В случае отказа, программа кладет на стол
//следующие верхние 2 карты для себя.
//7. Далее определяется победитель данного раунда по
//сумме значений карт.

//Требования к интерфейсу:
//1. Шрифт зеленого цвета.
//2. Текстовая информация должна очищаться после
//каждого раунда.
//3. В начале каждого раунда должен отображаться
//текущий счет.

namespace BlackJack
{
    class Program
    {
        public static int aggregateComputer = 0;
        public static int aggregatePlayer = 0;
        public static bool started = false;
        public static int sumPlayer;
        public static int sumComputer;
        public static int counter = 0;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
                        
            var deck = CreateTheDeck();         
                     
            for (;;)
            {
                
                if (!started)
                {
                    
                    
                    Console.WriteLine("* To shuffle the deck type - shuffle");
                    Console.WriteLine("* To show the deck type - show");
                    Console.WriteLine("* To start the game type - start");
                    string command = Console.ReadLine();
                    switch (command)
                    {
                        case "shuffle":
                            deck = ShuffleTheDeck(deck);
                            break;
                        case "show":
                            ShowDeck(deck);
                            break;
                        case "start":
                            StartTheGame(deck);
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
                            GiveOneMoreCard(deck);
                            counter++;
                            break;
                        case "stand":
                            Calculate(deck);
                            break;
                        default:
                            Console.WriteLine("You have entered an incorrect command!");
                            break;
                    }
                }
            }                                  
                                    
        }
        // *************************** Round's result ***********************
        private static void Calculate(List<KeyValuePair<string, int>> deck)
        {
            
            sumComputer = 0;
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(deck[i + counter + 2].Key);
                sumComputer += deck[i + counter + 2].Value;
            }

            if (sumPlayer > sumComputer)
            {
                Console.WriteLine("You Won!!!");                
                aggregatePlayer++;
                StartNewRound();

            }
            
            else if (sumPlayer < sumComputer)
            {
                Console.WriteLine("Computer Won.");                
                aggregateComputer++;
                StartNewRound();
            }

            else
            {
                Console.WriteLine("Draw.");                
                StartNewRound();
            }

            
        }
        //****************************** Hit the card ************************************
        private static void GiveOneMoreCard(List<KeyValuePair<string, int>> deck)
        {
            sumPlayer = 0;
            Console.WriteLine(deck[2+counter].Key);
            for (int i = 0; i <= counter + 2; i++)
            {
                sumPlayer += deck[i].Value;
            }
            if (sumPlayer > 21)
            {
                Console.WriteLine("You lose.");
                aggregateComputer++;
                StartNewRound();
            }
            
        }
        //*********************************** Clear and reset before next round ******************
        private static void StartNewRound()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key for starting the new round.");
            Console.ReadKey();
            counter = 0;
            started = false;
            Console.Clear();
            Console.WriteLine("TOTAL SCORE - Player {0} : {1} Computer", aggregatePlayer, aggregateComputer);
            Console.WriteLine();
        }
        // ************************************ Start the game ***********************************
        private static List<KeyValuePair<string, int>> StartTheGame(List<KeyValuePair<string, int>> deck)
        {
            sumPlayer = 0;
            for (int i = 0; i < 2; i++)
            {
                Console.Write(deck[i].Key+" ");
                sumPlayer += deck[i].Value;                     
            }
            if (sumPlayer == 22)
            {
                Console.WriteLine("You Won!!!");
                aggregatePlayer++;
                StartNewRound();
            }
            Console.WriteLine();
                        
            return deck;

        }
        //********************************** Shuffle the deck *****************************
        private static List<KeyValuePair<string, int>> ShuffleTheDeck(List<KeyValuePair<string, int>> deck)
        {
            var randomDeck = new List<KeyValuePair<string, int>>();
            Random rnd = new Random();
            randomDeck.Add(deck[rnd.Next(0, deck.Count)]);
            for (int i = 0; i < deck.Count - 1; i++)
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
        private static void ShowDeck(List<KeyValuePair<string, int>> createTheDeck)
        {
            for (int i = 0; i < createTheDeck.Count; i++)
            {
                Console.Write(createTheDeck[i].Key + " ");
            }
        }
        //*********************************** Create new deck *******************************      
        private static List<KeyValuePair<string, int>> CreateTheDeck()
        {
            var List = new List<KeyValuePair<string, int>>();

            Create("[S]", List);
            Create("[H]", List);
            Create("[D]", List);
            Create("[C]", List);

            return List;
        }

        private static void Create(string suit, List<KeyValuePair<string, int>> List)
        {
            for (int i = 0; i < 9; i++)
            {
                List.Add(new KeyValuePair<string, int>(Convert.ToString(i + 2) + suit, i + 2));
            }
            List.Add(new KeyValuePair<string, int>("Jack" + suit, 10));
            List.Add(new KeyValuePair<string, int>("Queen" + suit, 10));
            List.Add(new KeyValuePair<string, int>("King" + suit, 10));
            List.Add(new KeyValuePair<string, int>("Ace" + suit, 11));
        }

    }
}





