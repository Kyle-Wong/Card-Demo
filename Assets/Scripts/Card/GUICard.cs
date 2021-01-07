using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GUICard : MonoBehaviour
{

  // Use this for initialization
  GameController gameController;
  public Transform currCardMarker;
  private Card cardData;
  [HideInInspector]
  public bool isHeld;
  public Card CardData
  {
    get
    {
      return cardData;
    }
    set
    {
      cardData = value;
      UpdateCard(value);
    }
  }
  private Image image;
  public bool faceUp = true;
  void Awake()
  {
    image = transform.GetComponent<Image>();
    gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    isHeld = false;
  }

  // Update is called once per frame
  void Update()
  {
  }
  private void UpdateCard(Card card)
  {
    /*
      If card is faceup, get the correct sprite for the card's suit and rank
      from gameController
    */
    if (faceUp)
    {
      image.sprite = gameController.cardFronts[ImageCode()];
    }
    else
    {
      image.sprite = gameController.cardBack;
    }
  }
  private int ImageCode()
  {
    /*
      Get sprite index matching card's suit and rank stored in gameController
    */
    return (cardData.value - 1) * 4 + cardData.suit;
  }
  public void OnDrag()
  {
    /*
      If card can be picked up, then set its cardMarker to the cursor's position.
      Save the current cardMarker to return the card to its last valid location if needed.
      Set as last sibling to ensure card draws above all others.
    */
    if (currCardMarker == null || !currCardMarker.GetComponentInParent<CardsController>().CanRemoveCard(currCardMarker, transform))
    {
      return;
    }
    isHeld = true;
    image.raycastTarget = false;
    transform.SetAsLastSibling();

    Cursor.instance.PickUpCard(transform);

  }
  public void OnRelease(BaseEventData data)
  {
    if (!isHeld)
    {
      return;
    }
    isHeld = false;
    image.raycastTarget = true;
    Cursor.instance.DropCard((PointerEventData)data, currCardMarker, transform);
  }
  public void OnPointerEnter()
  {
    currCardMarker.GetComponent<CardMarker>().cardMarkerOwner.OnPointerEnter(transform, Cursor.instance.cardHeld);
  }
  public void OnPointerExit()
  {
    currCardMarker.GetComponent<CardMarker>().cardMarkerOwner.OnPointerExit(transform, Cursor.instance.cardHeld);
  }
}
