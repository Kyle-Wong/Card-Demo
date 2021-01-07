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
  protected CardList cardGroup;

  protected virtual void Awake()
  {
    cardGroup = new CardList();
  }

  public abstract void AddCard(Transform card);
  public abstract void RemoveCard(Transform card);
  public abstract bool CanAddCard(Transform cardMarker, Transform card);
  public abstract bool CanRemoveCard(Transform cardMarker, Transform card);

  public virtual void OnPointerEnter(Transform cardMarker, Transform card)
  {
    return;
  }
  public virtual void OnPointerExit(Transform cardMarker, Transform card)
  {
    return;
  }
}
