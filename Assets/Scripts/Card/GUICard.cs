using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GUICard : MonoBehaviour
{

  // Use this for initialization
  GameController gameController;
  public Transform currCardSlot;
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
      If card can be picked up, then set its CardSlot to the cursor's position.
      Save the current CardSlot to return the card to its last valid location if needed.
      Set as last sibling to ensure card draws above all others.
    */
    if (currCardSlot == null || !currCardSlot.GetComponentInParent<CardsController>().CanRemoveCard(currCardSlot, transform))
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
    /*
      Drop the held card. If there is a valid card slot, the card will be transferred to it.
      Otherwise, it returns to where it came from.
    */
    if (!isHeld)
    {
      return;
    }
    isHeld = false;
    image.raycastTarget = true;
    Cursor.instance.DropCard((PointerEventData)data, currCardSlot, transform);
  }
  public void OnPointerEnter()
  {
    /*
      Behavior determined by type of CardController that owns this slot
    */
    if (currCardSlot == null)
    {
      return;
    }
    currCardSlot.GetComponent<CardSlot>().CardSlotOwner.OnPointerEnter(transform, Cursor.instance.cardHeld);
  }
  public void OnPointerExit()
  {
    /*
      Behavior determined by type of CardController that owns this slot
    */
    if (currCardSlot == null)
    {
      return;
    }
    currCardSlot.GetComponent<CardSlot>().CardSlotOwner.OnPointerExit(transform, Cursor.instance.cardHeld);
  }
}
