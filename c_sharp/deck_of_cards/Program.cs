using System;

namespace deck_of_cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's play a card game!");
            Deck newGame = new Deck();
            newGame.Shuffle();
            Player person1 = new Player("Mary");
            Console.WriteLine("Welcome, {0}", person1.playerName);

            person1.Draw(newGame);
            person1.Discard(0);
            person1.Discard(0);          

            newGame.Reset();  
        }
    }
}
