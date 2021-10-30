using System;

namespace ohene
{
  class Program
  {
    static void Main(string[] args)
    {
      var keepPlaying = true;
      var game = new CrabSection();
      Console.WriteLine("######### WELCOME TO CRAB SECTION GAME #########");

      while (keepPlaying)
      {
        Console.WriteLine("Press any key to roll dice");
        Console.ReadLine();
        var (endGame, message, value) = game.Play();
        Console.WriteLine($"You played {value}");
        Console.WriteLine(message);
        keepPlaying = !endGame;
      }

      Console.WriteLine("Game Ended!");
      Console.ReadLine();
    }


  }
}
