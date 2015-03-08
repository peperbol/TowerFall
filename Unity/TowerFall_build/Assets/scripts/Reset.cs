using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour
{
  public void OnClick()
  {
    Application.LoadLevel(Application.loadedLevelName);

  }
}
