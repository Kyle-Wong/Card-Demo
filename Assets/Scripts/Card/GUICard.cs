using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GUICard : MonoBehaviour
{

  // Use this for initialization
  private GameController _gameController;
  private Transform _cardSlot;
  public Transform CardSlot
  {
    get
    {
      return _cardSlot;
    }
    set
    {
      if (_cardSlot != null)
      {
        _cardSlot.GetComponent<CardSlot>()._card = null;
      }
      _cardSlot = value;
    }
  }
  private Card _card;
  [HideInInspector]
  public bool IsHeld;
  public Card Card
  {
    get
    {
      return _card;
    }
    set
    {
      _card = value;
      UpdateCard(value);
    }
  }
  private Image _image;
  public bool FaceUp = true;
  void Awake()
  {
    _image = transform.GetComponent<Image>();
    _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    IsHeld = false;
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
    if (FaceUp)
    {
      _image.sprite = _gameController.CardFronts[ImageCode()];
    }
    else
    {
      _image.sprite = _gameController.CardBack;
    }
  }
  private int ImageCode()
  {
    /*
      Get sprite index matching card's suit and rank stored in gameController
    */
    return (_card.Value - 1) * 4 + _card.Suit;
  }
  public void OnDrag()
  {
    /*
      If card can be picked up, then set its CardSlot to the cursor's position.
      Save the current CardSlot to return the card to its last valid location if needed.
      Set as last sibling to ensure card draws above all others.
    */
    if (_cardSlot == null || !_cardSlot.GetComponentInParent<CardsController>().CanRemoveCard(_cardSlot, transform))
    {
      return;
    }
    IsHeld = true;
    _image.raycastTarget = false;
    transform.SetAsLastSibling();

    Cursor.Instance.PickUpCard(transform);

  }
  public void OnRelease(BaseEventData data)
  {
    /*
      Drop the held card. If there is a valid card slot, the card will be transferred to it.
      Otherwise, it returns to where it came from.
    */
    if (!IsHeld)
    {
      return;
    }
    IsHeld = false;
    _image.raycastTarget = true;
    Cursor.Instance.DropCard((PointerEventData)data, _cardSlot, transform);
  }
  public void OnPointerEnter()
  {
    /*
      Behavior determined by type of CardController that owns this slot
    */
    if (_cardSlot == null)
    {
      return;
    }
    _cardSlot.GetComponent<CardSlot>().CardSlotOwner.OnPointerEnter(transform, Cursor.Instance.CardHeld);
  }
  public void OnPointerExit()
  {
    /*
      Behavior determined by type of CardController that owns this slot
    */
    if (_cardSlot == null)
    {
      return;
    }
    _cardSlot.GetComponent<CardSlot>().CardSlotOwner.OnPointerExit(transform, Cursor.Instance.CardHeld);
  }
}
