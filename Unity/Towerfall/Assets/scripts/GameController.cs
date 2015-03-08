using UnityEngine;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

public static class GameController
{

  public static Player player;
  public static Timer timer;
  public static int LastFloorsReached = 0;
  public static bool gameOver =false;

  public static void GameOver()
  {
    if (!gameOver)
    {
      gameOver = true;

      LastFloorsReached = Statistics.FloorsReached;



      if (LastFloorsReached > ScoreReaderWriter.getHighscore())
      {
        ScoreReaderWriter.saveHighscore(LastFloorsReached);
      }
    }
  }

  public static void Reset()
  {
    gameOver = false;
    Statistics.Reset();
    FloorQueue.Reset();
  }
}
