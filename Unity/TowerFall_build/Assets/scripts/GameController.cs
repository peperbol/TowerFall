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
      GameObject.Destroy(player.rigidbody);
      GameObject.Destroy(GameObject.FindObjectOfType<Timer>());

      LastFloorsReached = Statistics.FloorsReached;

      RectTransform go = (RectTransform) GameObject.Instantiate(Resources.Load<RectTransform>("Prefabs/GameOver"));

      go.SetParent(GameObject.FindGameObjectWithTag("UICanvas").transform);
      go.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, Screen.height);
      go.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, Screen.width);


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
