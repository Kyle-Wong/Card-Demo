using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableauStack : StackController
{

  public override bool CanAddCard(CardSlot cardSlot, GUICard card)
  {
    //Can only add cards to the top of the stack and if it is a valid move
    if (_slotDistributor.IndexOf(cardSlot) != _slotDistributor.SlotCount - 1)
      return false;
    if (card.CardSlot.CardSlotOwner == cardSlot.CardSlotOwner)
    {
      print("no move");
      return false;
    }
    print(card.GetComponent<GUICard>().CardData.ToString() + ", " + CardList.Last().ToString());
    return Solitaire.ValidMove(card.GetComponent<GUICard>().CardData, CardList, Solitaire.Location.Tableau);
  }

  public override bool CanRemoveCard(CardSlot cardSlot, GUICard card)
  {
    //Only top card can be picked up
    return _slotDistributor.IndexOf(cardSlot) == _slotDistributor.SlotCount - 2;

  }
  public override void RemoveCard(GUICard card)
  {
    base.RemoveCard(card);
    if (_slotDistributor.SlotCount > 1)
    {
      //Reveal the facedown card beneath the card that was removed
      _slotDistributor.GetCardSlot(_slotDistributor.SlotCount - 2).GetComponent<CardSlot>().Card.FaceUp = true;
    }
  }
}
