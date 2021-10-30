using System;

namespace ohene
{
  public class CrabSection
  {

    private int NumberOfPlays = 0;
    private int? InitialValuePlayed = null;

    private Random _random = new Random();

    public int RollDice()
    {
      var dice1 = _random.Next(1, 7);
      var dice2 = _random.Next(1, 7);

      //Todo: Make it difficult to win

      return dice1 + dice2;
    }

    public Tuple<bool, string, int> Play()
    {
      NumberOfPlays++;

      var playedValue = RollDice();
      var result = GameRules(InitialValuePlayed, playedValue);
      var message = result switch
      {
        GameResult.Win => "Hurray! You won.",
        GameResult.Loss => "Awwww! You lost. Find money and play again.",
        _ => "Game On! Roll dice."
      };

      if (NumberOfPlays == 1) InitialValuePlayed = playedValue;

      return new Tuple<bool, string, int>(result != GameResult.Replay, message, playedValue);
    }

    public GameResult GameRules(int? initialValuePlayed, int CurrentValue)
    {
      return (initialValuePlayed, CurrentValue) switch
      {
        (null, 7 or 11) => GameResult.Win,
        (null, 2 or 3 or 12) => GameResult.Loss,
        (null, 4 or 5 or 6 or 8 or 9 or 10) => GameResult.Replay,
        (int, 7) => GameResult.Loss,
        (int, _) => (CurrentValue == InitialValuePlayed) ? GameResult.Win : GameResult.Replay
      };
    }


    public enum GameResult
    {
      Win,
      Loss,
      Replay
    }
  }


}