using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;

public class AnimationSoundSync : MonoBehaviour
{

  public string AnimationName;
  public float PlaysPerSpeedUnit = 1;
  public float MinSpeed = 0.2f;
  public bool Active= true;
  private Animation anim;
  private AudioSource sound;
  private float nextSoundTime  ;
  
	void Start ()
	{
	  anim = GetComponent<Animation>();
	  sound = GetComponent<AudioSource>();
	}
	
	void Update () {

    if (Active && Time.time > nextSoundTime && anim[AnimationName].speed > MinSpeed)
	  {
      sound.Play();
      nextSoundTime = Time.time + 1 / PlaysPerSpeedUnit / Mathf.Sqrt( anim[AnimationName].speed);
	  }
	}
}
