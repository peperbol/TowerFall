using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
  private float timeLeft =5 ;
  public Text TimeDisplay;
  public Text FloorsDisplay;

  private void Awake()
  {

    GameController.Reset();
  }

  private void Start()
  {
    GameController.timer = this;
  }

  void Update ()
	{
	  timeLeft -= Time.deltaTime;
    TimeDisplay.text = timeLeft.ToString("##0.0 'Sec.'");
    FloorsDisplay.text = Statistics.FloorsReached.ToString("##0 'Floors'");
    if (timeLeft < 0)
    {
      GameController.GameOver();
    }
	}

  public void AddTime()
  {
    timeLeft += Statistics.TimePerFloor;
  }
}
