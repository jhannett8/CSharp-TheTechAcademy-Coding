using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Dealer
    {
        public string Name { get; set; }
        public Deck Deck { get; set; }
        public int Balance { get; set; }

        public void Deal(List<Card> Hand)
        {
            Hand.Add(Deck.Cards.First());                                    //add first item 
            Console.WriteLine(Deck.Cards.First().ToString() + "\n");         //Print it on the console
            Deck.Cards.RemoveAt(0);                                          //Remove it from the deck
        }
    }
}
