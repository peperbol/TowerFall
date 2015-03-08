using UnityEngine;
using System.Collections;

public class testscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	  for (int i = 0; i < 5; i++)
	  {
	    FloorQueue.MakeNewFloor();
	  }
	}
	
}
