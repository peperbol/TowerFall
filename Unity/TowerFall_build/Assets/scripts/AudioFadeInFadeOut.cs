using UnityEngine;
using System.Collections;

public class AudioFadeInFadeOut : MonoBehaviour {
  public bool Active;
  [Range(0f,1f)]
  public float maxVolume;
  public float timeToFadeIn;
  public float timeToFadeOut;
  private AudioSource sound;
  public float volume;
	// Use this for initialization
	void Start () {
    sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	  if (Active)
	  {
	    volume += Time.deltaTime*maxVolume/timeToFadeIn;
	  }
	  else
    {
      volume -= Time.deltaTime * maxVolume / timeToFadeOut;
	  }
	  volume = Mathf.Clamp(volume, 0, maxVolume);
	  sound.volume = volume;
	}
}
