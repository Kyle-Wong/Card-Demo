using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardGroup
{

  // Use this for initialization
  /*
		Generic Container for anything that has a list of cards (hand, deck, stack).
		Child classes will pick a type of list (for efficient addition/removal of cards)
		based on their functionality.
		Enforce common method of adding and removing cards from groups.
	*/
  public Object cards;
  public CardGroup(Object cards)
  {
    this.cards = cards;
  }
  public abstract void addCard(Card card);
  public abstract void addCards(Card[] cards);
  public abstract void removeCard(Card card);
  public abstract void removeCards(Card card);

}
