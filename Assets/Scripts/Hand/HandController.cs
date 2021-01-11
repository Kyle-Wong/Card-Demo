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

  public void ShiftCard(CardSlot handCardSlot, CardSlot heldCardSlot)
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
    CardList.RearrangeCards(heldCardIndex, handCardIndex);
    _slotDistributor.RearrangeSlots(heldCardIndex, handCardIndex);
  }
  public override void OnPointerEnter(CardSlot cardSlot, GUICard heldCard)
  {
    if (heldCard == null)
    {
      return;
    }
    CardSlot heldCardSlot = heldCard.CardSlot;
    if (heldCardSlot.GetComponentInParent<HandController>() != null)
    {
      //Only shift cards if the held card is also from hand.
      ShiftCard(cardSlot, heldCardSlot);
    }
  }
  public override void AddCard(GUICard card)
  {

    CardSlot cardSlot = _slotDistributor.AddCardSlot().GetComponent<CardSlot>();
    card.CardSlot = cardSlot;
    CardList.AddCard(card.CardData);
  }
  public override void RemoveCard(GUICard card)
  {
    int cardIndex = CardList.RemoveCard(card.CardData);
    _slotDistributor.RemoveCardSpace(cardIndex);
  }
  public override bool CanAddCard(CardSlot cardSlot, GUICard card)
  {
    return false; //add cards through drawing from deck
  }
  public override bool CanRemoveCard(CardSlot cardSlot, GUICard card)
  {
    return true; //true for testing purposes
  }

}
