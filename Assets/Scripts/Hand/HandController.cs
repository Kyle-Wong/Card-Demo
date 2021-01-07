using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : CardsController
{

  // Use this for initialization
  CardDistributor cardDistributor;
  protected override void Awake()
  {
    base.Awake();
  }
  void Start()
  {
    cardDistributor = GetComponent<CardDistributor>();
  }

  public void ShiftCard(Transform handCardMarker, Transform heldCardMarker)
  {
    /*
      If the player is holding a card and hovers over a card in hand,
      reorder the cards in hand such that the marker for the card held by the cursor
      is at the cursor's current location. Shift all other cards to the right or left.
    */
    if (handCardMarker.Equals(heldCardMarker))
    {
      //Do nothing if both card markers are the same
      return;
    }
    int handCardIndex = cardDistributor.IndexOf(handCardMarker);
    int heldCardIndex = cardDistributor.IndexOf(heldCardMarker);
    print(heldCardIndex + ", " + handCardIndex);
    cardList.RearrangeCard(heldCardIndex, handCardIndex);
    cardDistributor.RearrangeMarker(heldCardIndex, handCardIndex);
  }
  public override void OnPointerEnter(Transform handCard, Transform heldCard)
  {
    if (heldCard == null)
    {
      return;
    }
    Transform heldCardMarker = heldCard.GetComponent<GUICard>().currCardMarker;
    Transform handCardMarker = handCard.GetComponent<GUICard>().currCardMarker;
    if (heldCardMarker.GetComponentInParent<HandController>() != null)
    {
      //Only shift cards if the held card is also from hand.
      ShiftCard(handCardMarker, heldCardMarker);
    }
  }
  public override void AddCard(Transform card)
  {

    Transform cardMarker = cardDistributor.AddCardSpace();
    card.GetComponent<GUICard>().currCardMarker = cardMarker;
    cardList.AddCard(card.GetComponent<GUICard>().CardData);
  }
  public override void RemoveCard(Transform card)
  {
    Card cardData = card.GetComponent<GUICard>().CardData;
    int cardIndex = cardList.RemoveCard(cardData);
    cardDistributor.RemoveCardSpace(cardIndex);
  }
  public override bool CanAddCard(Transform cardMarker, Transform card)
  {
    return false; //add cards through drawing from deck
  }
  public override bool CanRemoveCard(Transform cardMarker, Transform card)
  {
    return true; //true for testing purposes
  }

}
