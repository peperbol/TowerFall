using System;
using UnityEngine;
using System.Collections;

public class SpriteSheet : MonoBehaviour
{
  public int _uvTieX = 1;
  public int _fps = 10;
  public float delay;

  private bool playing = false;

  private Vector2 _size;
  private Renderer _myRenderer;
  private int _lastIndex = -1;
  private float playTime = 0;

  public void Play()
  {
    playing = true;
    playTime = Time.time + delay;
  }

  void Start()
  {
    _size = new Vector2( 1.0f/_uvTieX, 1);
    _myRenderer = renderer;
    if (_myRenderer == null)
      enabled = false;
  }

  // Update is called once per frame
  private void Update()
  {
    if (playing)
    {
      // Calculate index
      int index = Mathf.Clamp((int) ((Time.time - playTime)*_fps), 0 ,_uvTieX - 1);

      if (index != _lastIndex)
      {

        // build offset
        // v coordinate is the bottom of the image in opengl so we need to invert.
        Vector2 offset = new Vector2(index*_size.x, 0);

        _myRenderer.material.SetTextureOffset("_MainTex", offset);
        _myRenderer.material.SetTextureScale("_MainTex", _size);

        _lastIndex = index;
      }
    }
  }
}
