using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
  public bool IsGap;
  private Floor floor;

  private void OnTriggerEnter(Collider collider)
  {
    if (collider.GetComponent<Player>() != null)
    {
      if (IsGap)
      {
        floor.FallThrough();
        collider.GetComponent<Player>().StartFalling(floor);
      }
      else if (collider.GetComponent<Player>().CurrentFloor != floor)
      {
        collider.GetComponent<Player>().Land(floor);
        floor.BeLandedOn();
      }
      
    }
  }

  void Start ()
  {
    floor = transform.parent.GetComponent<Floor>();
  }
}
