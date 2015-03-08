using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

public static class FloorQueue
{

  private static Queue<Floor> queue = new Queue<Floor>();

  public static void Enqueue(Floor floorToEnqueue)
  {
    queue.Enqueue(floorToEnqueue);
  }

  public static void MakeNewFloor()
  {
    queue.Enqueue((Floor)GameObject.Instantiate(Resources.Load<Floor>("Prefabs/Floor"),new Vector3(0,Statistics.NextYCoordinate,0),Quaternion.identity ));
  }

  public static void DiscardPreviousFloor()
  {
    if(queue.Count>0)
    GameObject.Destroy( queue.Dequeue().gameObject);
  }

  public static Floor[] FloorsAsArray
  {
    get { return queue.ToArray(); }
  }

  public static void Reset()
  {
    queue = new Queue<Floor>();
  }

}
