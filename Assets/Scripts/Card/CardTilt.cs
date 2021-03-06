﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTilt : MonoBehaviour
{
  /*
    Tilt held cards in the direction of travel.
    tiltScale determines how much tilt can occur.
    tiltSpeed determines how quickly the card will tilt.
  */
  public Vector2 TiltScale;
  public float TiltSpeed;
  private GUICard _card;
  private Vector3 _prevPosition;
  private bool _returningToIdentityRotation;
  void Start()
  {
    _card = GetComponent<GUICard>();
    _prevPosition = transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    if (_card.IsHeld)
    {
      Vector2 velocity = transform.position - _prevPosition;
      transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(-velocity.y * TiltScale.y, velocity.x * TiltScale.x, 0)), TiltSpeed * Time.deltaTime);
      _returningToIdentityRotation = true;
    }
    else if (_returningToIdentityRotation)
    {
      //Return to non-rotated rotation
      transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, TiltSpeed * Time.deltaTime);
      if (Vector3.Magnitude(transform.eulerAngles - Quaternion.identity.eulerAngles) < 0.05f)
      {
        //Stop controlling rotation once card is sufficiently close to identity quaternion
        transform.rotation = Quaternion.identity;
        _returningToIdentityRotation = false;
      }
    }
    //for tracking card's velocity
    _prevPosition = transform.position;
  }
}

