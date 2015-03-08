using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour
{
  public string levelName;
  public void OnClick()
  {
    GameController.Reset();
    Application.LoadLevel(levelName);
  }
}
