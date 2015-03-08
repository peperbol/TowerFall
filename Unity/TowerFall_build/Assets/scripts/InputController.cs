using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
  public float maxMoveValue = 2.5f;

	void FixedUpdate ()
	{
	    // Debug.Log( Input.gyro.attitude);
	    if (Input.touchCount > 0)
	    {

	      float maxDistance = Mathf.Min(Screen.width, Screen.height)/2/maxMoveValue;
	      GameController.player.Move(new Vector2((Input.GetTouch(0).position.x - Screen.width/2)/maxDistance,
	        (Input.GetTouch(0).position.y - Screen.height/2)/maxDistance));

	    
	    /*
       * Desktop
	  Vector2 direction = new Vector2(0,0);
	  if (Input.GetKey("q"))
	  {
      direction += -Vector2.right;
	  }

    if (Input.GetKey("z"))
    {
      direction +=  Vector2.up;
    }
    if (Input.GetKey("d"))
    {
      direction += Vector2.right;
    }

    if (Input.GetKey("s"))
    {
      direction += -Vector2.up;
    }
    GameController.player.Move(direction);*/
	  }
	}
}
