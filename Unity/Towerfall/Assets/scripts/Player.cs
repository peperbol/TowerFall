using System;
using UnityEngine;
using System.Collections;
using System.Xml.Schema;

public class Player : MonoBehaviour
{
  public float MoveSpeed;
  public bool isFalling ;
  public Animation anim;
  private float animMaxSpeed;
  private float velocityForMaxSpeed = 0.5f;
  private float velocityOfRest = 0.05f;
  private Floor currentFloor;

  public Floor CurrentFloor {
    get { return currentFloor; }
  }

  public void Move(Vector2 direction)
  {
    if (!isFalling)
    {
      float newMagnitude = Mathf.Clamp(direction.magnitude, 0, 1);
      direction.Normalize();
      direction *= newMagnitude;
      if (!GameController.gameOver )
      rigidbody.AddForce(new Vector3(direction.x, 0, direction.y)*MoveSpeed);
    }
  }

  private void Update()
  {

    if (!GameController.gameOver)
    {
      Vector3 vec = rigidbody.velocity;
      Debug.Log(rigidbody.velocity.magnitude);
      vec.y = 0;
      if (rigidbody.velocity.sqrMagnitude > velocityOfRest)
      {
        
          vec.Normalize();
        float i = Mathf.Asin(vec.x) * 180 / Mathf.PI;
        if (vec.z < 0) i = 180 - i;
        anim.transform.rotation = Quaternion.AngleAxis(i, Vector3.up);
      }
      anim["walk"].speed = animMaxSpeed * Mathf.Clamp( rigidbody.velocity.magnitude,0,3) / velocityForMaxSpeed;
    }
  }

  public void StartFalling(Floor throughFloor)
  {
    isFalling = true;
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
    currentFloor = onFloor;
  }

  void Start()
  {
    animMaxSpeed = anim["walk"].speed;
    GameController.player = this;
  }

}
