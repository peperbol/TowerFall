using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour
{

  public static int Width {
    get { return 9; }
  }
  public static int Heigth
  {
    get { return 9; }
  }


  private bool hasBeenLandedOn = false;

  private bool hasFallenThrough = false;

  public bool HasBeenLandedOn
  {
    get { return hasBeenLandedOn; }
  }

  public void BeLandedOn()
  {
    if (!hasBeenLandedOn)
    {
      hasBeenLandedOn = true;
      GameController.timer.AddTime();
    }

  }

  public void FallThrough()
  {
    if (!hasFallenThrough)
    {
      hasFallenThrough = true;
      FloorQueue.MakeNewFloor();
    }
  }

  private void Update()
  {
    if (hasFallenThrough && transform.position.y - GameController.player.transform.position.y > Statistics.DistanceBewteenFloors)
    {
      FloorQueue.DiscardPreviousFloor();
    }
  }

	void Start ()
	{
	  int childsToGo = Width*Heigth;
	  int amountOfTilesToSpawn = Mathf.RoundToInt(childsToGo*Statistics.FloorDensity);

	  Tile TilePrefab = Resources.Load<Tile>("Prefabs/Tile");
	  Tile GapPrefab= Resources.Load<Tile>("Prefabs/Gap");

	  for (int x = 0; x < Width; x++)
	  {
	    for (int z = 0; z < Heigth; z++)
	    {
	      Tile newChild;
	      if (Random.value < (amountOfTilesToSpawn/(float) childsToGo))
	      {
          newChild = (Tile)Instantiate(TilePrefab, new Vector3(x, transform.position.y, z), Quaternion.identity);
	        amountOfTilesToSpawn --;
	      }
	      else
	      {
          newChild = (Tile)Instantiate(GapPrefab, new Vector3(x, transform.position.y, z), Quaternion.identity);
	      }
        newChild.transform.SetParent(transform);

	      childsToGo--;
	    }
	  }
	}
}
