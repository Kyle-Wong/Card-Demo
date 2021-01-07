using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTilt : MonoBehaviour
{
  /*
    Tilt held cards in the direction of travel.
    tiltScale determines how much tilt can occur.
    tiltSpeed determines how quickly the card will tilt.
  */
  public Vector2 tiltScale;
  public float tiltSpeed;
  private GUICard card;
  private Vector3 prevPosition;
  void Start()
  {
    card = GetComponent<GUICard>();
    prevPosition = transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    if (card.isHeld)
    {
      Vector2 velocity = transform.position - prevPosition;
      transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(-velocity.y * tiltScale.y, velocity.x * tiltScale.x, 0)), tiltSpeed * Time.deltaTime);
    }
    else
    {
      //Return to non-rotated rotation
      transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, tiltSpeed * Time.deltaTime);
    }
    //for tracking card's velocity
    prevPosition = transform.position;
  }
}

