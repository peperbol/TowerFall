using UnityEngine;
using System.Collections;

public class CameraFovFix : MonoBehaviour
{
  public float SmallestFOV = 60;
	
	void Update ()
	{
	    float aspectRatio = Screen.width/(float) Screen.height;
	    if (aspectRatio > 1)
	    {
	      camera.fieldOfView = SmallestFOV/aspectRatio;
	    }
	    else
	    {
	      camera.fieldOfView = SmallestFOV;
	    }
	  
	}
}
