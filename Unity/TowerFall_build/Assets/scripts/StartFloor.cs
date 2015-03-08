using UnityEngine;
using System.Collections;

public class StartFloor : MonoBehaviour {

	// Use this for initialization
	void Start () {
    FloorQueue.Enqueue(GetComponent<Floor>());

    for (int i = 0; i < 4; i++)
    {
      FloorQueue.MakeNewFloor();
    }
	}
}
