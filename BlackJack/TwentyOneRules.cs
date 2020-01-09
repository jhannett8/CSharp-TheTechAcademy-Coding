using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace BlackJack
{
    public class TwentyOneRules
    {
        //private: will only be used inside of this class
        //static:  dont need to instantiate the object to access this method
        //the naming conventions for private methods is to use an "_..." before the name of the method
        //So here we are creating a new dictionary and instantiating it with all of our key.value pairs 
        //why dont we use enums? bc enums dont do well with corresponding values
        private static Dictionary<Face, int> _cardValues = new Dictionary<Face, int>()
        {
            [Face.Two] = 2,
            [Face.Three] = 3,
            [Face.Four] = 4,
            [Face.Five] = 5,
            [Face.Six] = 6,
            [Face.Seven] = 7,
            [Face.Eight] = 8,
            [Face.Nine] = 9,
            [Face.Ten] = 10,
            [Face.Jack] = 10,
            [Face.Queen] = 10,
            [Face.King] = 10,
            [Face.Ace] = 1    //WILL DO LOGIC LATER THAT WILL ADD TEN IF NEED BE AS PER THE GAME
        };
        private static int[] GetAllPossibleHandValues(List<Card> Hand)
        {
            //finds out how many aces there are
            //take each item in hand<list> and check is the cards face equivalent to an ace and will return a count in the form of the varibale aceoutn 
            int AceCount = Hand.Count(x => x.Face == Face.Ace);
            int[] result = new int[AceCount + 1];
            int value = Hand.Sum(x => _cardValues[x.Face]);
            result[0] = value;
            if (result.Length == 1)
            {
                return result;
            }
            for (int i = 1; i < result.Length; i++)
            {
                value += (i * 10);
                result[i] = value;
            }
            return result;
        }

        public static bool CheckForBlackJack(List<Card> Hand)
        {
            int[] possibleValues = GetAllPossibleHandValues(Hand);
            int value = possibleValues.Max();
            if (value == 21) return true;
            else return false;
        }

        public static bool IsBusted(List<Card> Hand)
        {
            int value = GetAllPossibleHandValues(Hand).Min();
            if (value > 21) return true;
            else return false;
        }

        public static bool ShouldDealerStay(List<Card> Hand)
        {
            int[] possibleHandValues = GetAllPossibleHandValues(Hand);
            foreach (int value in possibleHandValues)
            {
                if (value > 16 && value < 22)
                {
                    return true; 
                }
            }
            return false;
        }

        public static bool? CompareHands(List<Card> PlayerHand, List<Card> DealerHand)
        {
            int[] playerResults = GetAllPossibleHandValues(PlayerHand);
            int[] dealerResults = GetAllPossibleHandValues(DealerHand);
            //Takes the items from player results and filters them through lambda expressions 
            //Give me a list of player results where the item is less then 22
            //then get me the largest value from that list 

            int playerScore = playerResults.Where(x => x < 22).Max();
            int dealerScore = dealerResults.Where(x => x < 22).Max();

            //if the player beats the dealer return tru
            //if the dealer beats the player return false
            //if they equal return null, no one wins
            if (playerScore > dealerScore) return true;
            else if (playerScore < dealerScore) return false;
            else return null;
        }
    }
}
