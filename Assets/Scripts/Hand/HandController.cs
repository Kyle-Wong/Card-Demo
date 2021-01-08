using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : CardsController
{

  // Use this for initialization
  private SlotDistributor _slotDistributor;
  protected override void Awake()
  {
    base.Awake();
  }
  void Start()
  {
    _slotDistributor = GetComponent<SlotDistributor>();
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
    int handCardIndex = _slotDistributor.IndexOf(handCardSlot);
    int heldCardIndex = _slotDistributor.IndexOf(heldCardSlot);
    _cardList.RearrangeCards(heldCardIndex, handCardIndex);
    _slotDistributor.RearrangeSlots(heldCardIndex, handCardIndex);
  }
  public override void OnPointerEnter(Transform handCard, Transform heldCard)
  {
    if (heldCard == null || heldCard.GetComponent<GUICard>() == null)
    {
      return;
    }
    Transform heldCardSlot = heldCard.GetComponent<GUICard>().CardSlot;
    Transform handCardSlot = handCard.GetComponent<GUICard>().CardSlot;
    if (heldCardSlot.GetComponentInParent<HandController>() != null)
    {
      //Only shift cards if the held card is also from hand.
      ShiftCard(handCardSlot, heldCardSlot);
    }
  }
  public override void AddCard(Transform card)
  {

    Transform cardSlot = _slotDistributor.AddCardSpace();
    card.GetComponent<GUICard>().CardSlot = cardSlot;
    _cardList.AddCard(card.GetComponent<GUICard>().Card);
  }
  public override void RemoveCard(Transform card)
  {
    Card cardData = card.GetComponent<GUICard>().Card;
    int cardIndex = _cardList.RemoveCard(cardData);
    _slotDistributor.RemoveCardSpace(cardIndex);
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
