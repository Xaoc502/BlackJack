using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack3
{
    class Program
    {      
        static void Main(string[] args)
        {
            //GameConsole gameConsole = new GameConsole();
            GameConsole.StartGame();
            //console.ShowTheDeck(deck);
            //Console.WriteLine();
            //Console.WriteLine();
            //deck.ShuffleTheDeck();
            //Console.WriteLine(); Console.WriteLine();
            //console.ShowTheDeck(deck);
            Console.ReadKey();
                        
           
            GameRules rules = new GameRules();

            
            Console.ReadKey();
            
        }
    }
}
