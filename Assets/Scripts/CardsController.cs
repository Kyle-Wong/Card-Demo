using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardsController : MonoBehaviour
{

  // Use this for initialization
  /*
		Parent class for anything that can "own" cards, such as the
		player's hand or spots where cards can be played.

		Cards are moved from one area to another via these shared methods.
		If a card can be played from hand, for example, it should RemoveCard from hand
		and AddCard to destination.
	*/
  protected CardList _cardList;

  protected virtual void Awake()
  {
    _cardList = new CardList();
  }

  public abstract void AddCard(GUICard card);
  public abstract void RemoveCard(GUICard card);
  public abstract bool CanAddCard(CardSlot cardSlot, GUICard card);
  public abstract bool CanRemoveCard(CardSlot cardSlot, GUICard card);

  public virtual void OnPointerEnter(CardSlot cardSlot, GUICard card)
  {
    return;
  }
  public virtual void OnPointerExit(CardSlot cardSlot, GUICard card)
  {
    return;
  }
}
