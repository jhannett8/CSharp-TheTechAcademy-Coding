using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace BlackJack
{
    public class Deck
    {
        //Constructor
        public Deck()
        {
           Cards = new List<Card>();

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Card card = new Card();
                    card.Face = (Face)i;  //j is an integer j=0 at Face=Two
                    card.Suit = (Suit)j;
                    Cards.Add(card);
                }
            }   
        }

        //Property 
        public List<Card> Cards { get; set; } 

        //shuffle method
        public void Shuffle(int times = 1)
        {
            
            for (int i = 0; i < times; i++)
            {
                List<Card> TempList = new List<Card>();
                Random random = new Random();

                while (Cards.Count > 0)
                {
                    int randomIndex = random.Next(0, Cards.Count);
                    TempList.Add(Cards[randomIndex]);
                    Cards.RemoveAt(randomIndex);
                }
                Cards = TempList;
            }
            

        }
    }
}
