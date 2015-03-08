using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScalingText : MonoBehaviour
{
  public Text text;
  public Image parent;
  public float maxXScale;
  public float maxYScale;

	// Use this for initialization
	void Update ()
	{
    float arImage = (float) parent.mainTexture.width / parent.mainTexture.height;
	  float arCanvas = parent.rectTransform.rect.width/parent.rectTransform.rect.height;
    text.fontSize = (int) ((arCanvas > arImage) ? (parent.rectTransform.rect.height * maxYScale) : (parent.rectTransform.rect.width * maxXScale)); 
    text.rectTransform.rect.Set(text.rectTransform.rect.x, text.rectTransform.rect.y, text.rectTransform.rect.width, text.fontSize);
	}

}
