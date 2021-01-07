using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : CardsController
{

  // Use this for initialization
  SlotDistributor cardDistributor;
  protected override void Awake()
  {
    base.Awake();
  }
  void Start()
  {
    cardDistributor = GetComponent<SlotDistributor>();
  }

  public void ShiftCard(Transform handCardSlot, Transform heldCardSlot)
  {
    /*
      If the player is holding a card and hovers over a card in hand,
      reorder the cards in hand such that the slot for the card held by the cursor
      is at the cursor's current location. Shift all other cards to the right or left.
    */
    if (handCardSlot.Equals(heldCardSlot))
    {
      //Do nothing if both card slot are the same
      return;
    }
    int handCardIndex = cardDistributor.IndexOf(handCardSlot);
    int heldCardIndex = cardDistributor.IndexOf(heldCardSlot);
    cardList.RearrangeCards(heldCardIndex, handCardIndex);
    cardDistributor.RearrangeSlots(heldCardIndex, handCardIndex);
  }
  public override void OnPointerEnter(Transform handCard, Transform heldCard)
  {
    if (heldCard == null)
    {
      return;
    }
    Transform heldCardSlot = heldCard.GetComponent<GUICard>().currCardSlot;
    Transform handCardSlot = handCard.GetComponent<GUICard>().currCardSlot;
    if (heldCardSlot.GetComponentInParent<HandController>() != null)
    {
      //Only shift cards if the held card is also from hand.
      ShiftCard(handCardSlot, heldCardSlot);
    }
  }
  public override void AddCard(Transform card)
  {

    Transform cardSlot = cardDistributor.AddCardSpace();
    card.GetComponent<GUICard>().currCardSlot = cardSlot;
    cardList.AddCard(card.GetComponent<GUICard>().CardData);
  }
  public override void RemoveCard(Transform card)
  {
    Card cardData = card.GetComponent<GUICard>().CardData;
    int cardIndex = cardList.RemoveCard(cardData);
    cardDistributor.RemoveCardSpace(cardIndex);
  }
  public override bool CanAddCard(Transform cardSlot, Transform card)
  {
    return false; //add cards through drawing from deck
  }
  public override bool CanRemoveCard(Transform cardSlot, Transform card)
  {
    return true; //true for testing purposes
  }

}
