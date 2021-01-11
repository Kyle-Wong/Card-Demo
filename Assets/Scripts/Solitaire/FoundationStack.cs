using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundationStack : StackController
{
  public override bool CanAddCard(CardSlot cardSlot, GUICard card)
  {
    //Can only add cards to the top of the stack and if it is a valid move
    if (_slotDistributor.IndexOf(cardSlot) != _slotDistributor.SlotCount - 1)
      return false;
    return Solitaire.ValidMove(card.CardData, _cardList, Solitaire.Location.Foundation);
  }

  public override bool CanRemoveCard(CardSlot cardSlot, GUICard card)
  {
    //Only top card can be picked up
    return _slotDistributor.IndexOf(cardSlot) == _slotDistributor.SlotCount - 1;

  }
  public bool Completed()
  {
    return _cardList.Count == 13;
  }

}
