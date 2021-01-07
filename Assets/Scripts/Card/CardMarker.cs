using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMarker : MonoBehaviour
{

  // Use this for initialization
  public CardsController cardMarkerOwner;
  void Start()
  {
    cardMarkerOwner = GetComponentInParent<CardsController>();
  }

  // Update is called once per frame
  void Update()
  {

  }

}
