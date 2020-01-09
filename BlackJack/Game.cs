using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public abstract class Game                                 //An abstract class is like a base class.  You will not make an object from it so it can not be instantiated
                                                               //But the class is used through inheritance as a model for other classes to use 
    {
        private List<Player> _players = new List<Player>();                     //we made this bc whenever you try to add anything to an empty list, it will throw an error your way 
                                                                                //This technique ensures the list isnt empty 
        private Dictionary<Player, int> _bets = new Dictionary<Player, int>();
        public List<Player> Players { get { return _players; } set { _players = value; } }
        public string Name { get; set;  }
        public Dictionary<Player, int> Bets { get { return _bets; } set { _bets = value; } }      
        public abstract void Play();                           //any class inheriting this class, must have a play method 
        public virtual void ListPlayers()                      //virtual method (with abstract class) means that this method gets inherited but can override 
        {
            foreach (Player player in Players)
            {
                Console.WriteLine(player.Name);
            }
        }
    }
}
