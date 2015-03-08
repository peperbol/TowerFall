using UnityEngine;
using System.Collections;

public static class ParalaxController
{

  public static float MaxOffsetDistancePerFloor = 3.5f;
	// Update is called once per frame
	public static void Update (float xAxis, float yAxis)
	{
	  Vector3 reference = GameController.player.CurrentFloor.transform.position;
	  Floor[] floors = FloorQueue.FloorsAsArray;
	  int indexOffset = 0;

    float xOffset = MaxOffsetDistancePerFloor * xAxis;
    float yOffset = MaxOffsetDistancePerFloor * yAxis;

	  for (int i = 0; i < floors.Length; i++)
	  {
	    if (floors[i] == GameController.player.CurrentFloor)
	    {
	      indexOffset = -i;
	    }
	  }

	  for (int i = 0; i < floors.Length; i++)
	  {
      floors[i].transform.position = new Vector3(reference.x + (xOffset * (i - indexOffset)), floors[i].transform.position.y, reference.y + (yOffset * (i - indexOffset)));
	  }
	}
}
