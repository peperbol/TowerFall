using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighscoreText : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{

	  GetComponent<Text>().text = "Highscore: " + ScoreReaderWriter.getHighscore() + "\n"+
                                "Your score: "+ GameController.LastFloorsReached;
	}
	
}
