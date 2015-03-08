using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  public float MoveSpeed;
  public bool isFalling ;
  public Animation Anim;
  public AnimationSoundSync WalkingSound;
  public AudioSource DeathSound;
  public AudioFadeInFadeOut FallingSound;
  public float TimeToDie;
  public Image Black;
  public float TimeBeforeFadeOut;
  public float TimeFadingOut;
  public SpriteSheet Splat;

  private float animMaxSpeed;
  private float velocityForMaxSpeed = 0.5f;
  private float velocityOfRest = 0.2f;
  private Floor currentFloor;
  private float timeOfDeath = -1;
  private float fadeOutStart = -1;
  private bool fadingOut = false;

  public Floor CurrentFloor {
    get { return currentFloor; }
  }

  public void Move(Vector2 direction)
  {
    if (!isFalling)
    {
      if (!GameController.gameOver)
      {
        float newMagnitude = Mathf.Clamp(direction.magnitude, 0, 1);
        direction.Normalize();
        direction *= newMagnitude;
        if (!GameController.gameOver)
          rigidbody.AddForce(new Vector3(direction.x, 0, direction.y)*MoveSpeed);
      }
    }
  }

  private void Update()
  {
    if (!GameController.gameOver)
    {
      Vector3 vec = rigidbody.velocity;
      vec.y = 0;
      if (rigidbody.velocity.sqrMagnitude > velocityOfRest)
      {

        vec.Normalize();
        float i = Mathf.Asin(vec.x)*180/Mathf.PI;
        if (vec.z < 0) i = 180 - i;
        Anim.transform.rotation = Quaternion.AngleAxis(i, Vector3.up);
      }
      Anim["walk"].speed = animMaxSpeed*Mathf.Clamp(rigidbody.velocity.magnitude, 0, 3)/velocityForMaxSpeed;
    }
    else
    {

      if (fadeOutStart < 0)
      {
        fadeOutStart = Time.time + TimeBeforeFadeOut;
      }

      if (!fadingOut && Time.time < fadeOutStart)
      {
        if (!isFalling)
        {
          if (timeOfDeath < 0)
          {

            timeOfDeath = Time.time + TimeToDie;

            WalkingSound.Active = false;
            DeathSound.Play();
            Anim.Play("death1");
            Splat.Play();
          }

          if (Time.time >= timeOfDeath)
          {
            Application.LoadLevel("GameOver");
          }
        }
      }
      else if (!fadingOut)
      {
         fadingOut = true;
         timeOfDeath = Time.time + TimeFadingOut;
         FallingSound.Active = false;
      }

      if (fadingOut)
      {
        Color c = Black.color;
        c.a = (Time.time - fadeOutStart)/TimeFadingOut;
        Black.color = c;
        if (Time.time >= timeOfDeath)
        {
          
            Application.LoadLevel("GameOver");
        }
      }

    }
  }

  public void StartFalling(Floor throughFloor)
  {
    isFalling = true;
    WalkingSound.Active = false;
    FallingSound.Active = true;
    if (throughFloor != currentFloor)
    {
      GameController.GameOver();
    }
    Vector3 velocity = rigidbody.velocity;
    velocity.x = 0;
    velocity.z = 0;
    rigidbody.velocity = velocity;
  }

  public void Land(Floor onFloor)
  {
    isFalling = false;
    WalkingSound.Active = true;
    FallingSound.Active = false;
    currentFloor = onFloor;
  }


  void Start()
  {
    animMaxSpeed = Anim["walk"].speed;
    GameController.player = this;
  }

}
