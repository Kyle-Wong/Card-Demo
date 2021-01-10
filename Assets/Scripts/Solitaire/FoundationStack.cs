using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundationStack : StackController
{
  public override bool CanAddCard(Transform cardSlot, Transform card)
  {
    //Can only add cards to the top of the stack and if it is a valid move
    if (_slotDistributor.IndexOf(cardSlot) != _slotDistributor.SlotCount - 1)
      return false;
    return Solitaire.ValidMove(card.GetComponent<Card>(), _cardList, Solitaire.Location.Foundation);
  }

  public override bool CanRemoveCard(Transform cardSlot, Transform card)
  {
    //Only top card can be picked up
    return _slotDistributor.IndexOf(cardSlot) == _slotDistributor.SlotCount - 1;

  }
  public bool Completed()
  {
    return _cardList.Count == 13;
  }

}
