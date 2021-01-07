using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlot : MonoBehaviour
{
  /*
		Card Slots are essentially places where cards can potentially be placed.
		Whenever a card is given a reference to a CardSlot, it rapidly moves towards it.
		Depending on the logic in the CardSlot's owner, a card may or may not be placed
		in a given CardSlot.
	*/
  public CardsController CardSlotOwner;
  void Start()
  {
    CardSlotOwner = GetComponentInParent<CardsController>();
  }

  // Update is called once per frame
  void Update()
  {

  }

}
