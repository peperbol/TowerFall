using UnityEngine;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

public static class Statistics
{

  private static float floorDensity = 0.6f;
  private static float falloff = 0.97f;
  private static float denstityRandomisationRange = 0.15f;
  private static int floorsReached = 0;
  private static float timePerFloor = 5f;
  private static float lastYcoordinate = 0;

  public static float DistanceBewteenFloors
  {
    get { return 5; }
  }

  public static float NextYCoordinate
  {
    get
    {
      lastYcoordinate -= DistanceBewteenFloors;
      return lastYcoordinate;
    }
  }

  public static float TimePerFloor
  {
    get
    {
      timePerFloor *= falloff;
      floorsReached ++;
      return timePerFloor;
    }
  }

  public static int FloorsReached
  {
    get { return floorsReached; }
  }


  public static float FloorDensity
  {
    get
    {
      floorDensity *= falloff;
      return floorDensity + Random.Range(-floorDensity*denstityRandomisationRange, floorDensity*denstityRandomisationRange);
    }
  }

  public static void Reset()
  {
    floorDensity = 0.6f;
    timePerFloor = 3f;
    floorsReached = 0;
    lastYcoordinate = 0;
  }
}
