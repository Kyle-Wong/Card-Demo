using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GUICard : MonoBehaviour
{

  // Use this for initialization
  private GameController _gameController;
  private CardSlot _cardSlot;
  public CardSlot CardSlot
  {
    get
    {
      return _cardSlot;
    }
    set
    {
      if (_cardSlot != null)
      {
        _cardSlot.GetComponent<CardSlot>().Card = null;
      }
      _cardSlot = value;
      _cardSlot.GetComponent<CardSlot>().Card = this;
    }
  }
  private Card _cardData;
  [HideInInspector]
  public bool IsHeld;
  public Card CardData
  {
    get
    {
      return _cardData;
    }
    set
    {
      _cardData = value;
      UpdateImage();
    }
  }
  private Image _image;
  private bool _faceUp;
  public float FlipSpeed;
  void Awake()
  {
    _image = transform.GetComponent<Image>();
    _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    IsHeld = false;
  }
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
  }
  private void UpdateImage()
  {
    /*
      If card is faceup, get the correct sprite for the card's suit and rank
      from gameController
    */
    if (FaceUp())
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
    return (_cardData.Value - 1) * 4 + _cardData.Suit;
  }
  public void SetFaceUp(bool faceUp, bool instantFlip = false)
  {
    if (!instantFlip && faceUp != _faceUp)
    {
      //Flip only when the facing direction actually changes
      //Card image updates during coroutine
      _faceUp = faceUp;
      StartCoroutine(Flip(FlipSpeed));
    }
    else
    {
      _faceUp = faceUp;
      UpdateImage();
    }
  }
  public bool FaceUp()
  {
    return _faceUp;
  }
  private IEnumerator Flip(float flipSpeed)
  {
    /*
      Animation to flip card, switching between card front and card back when it is vertical to the camera.
    */
    while (transform.eulerAngles.y < 90)
    {
      transform.Rotate(Vector3.up, flipSpeed * Time.deltaTime);
      yield return null;

    }
    UpdateImage();
    float y = transform.eulerAngles.y;
    //eulerAngles are [0-360], so end loop when eulerangles.y passes 0 and becomes 359.x
    while (transform.eulerAngles.y <= y)
    {
      transform.Rotate(Vector3.up, -flipSpeed * Time.deltaTime);
      yield return null;
    }
    transform.rotation = Quaternion.identity;
  }
  public void OnDrag()
  {
    /*
      If card can be picked up, then set its CardSlot to the cursor's position.
      Save the current CardSlot to return the card to its last valid location if needed.
      Set as last sibling to ensure card draws above all others.
    */
    if (CardSlot == null || CardSlot.CardSlotOwner == null || !CardSlot.CardSlotOwner.CanRemoveCard(CardSlot, this))
    {
      return;
    }
    IsHeld = true;
    _image.raycastTarget = false;
    transform.SetAsLastSibling();

    Cursor.Instance.PickUpCard(this);

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
    Cursor.Instance.DropCard((PointerEventData)data, CardSlot, this);
  }
  public void OnPointerEnter()
  {
    /*
      Behavior determined by type of CardController that owns this slot
      Mark this card as the one under the cursor
    */
    if (FaceUp())
      Cursor.Instance.CardUnderCursor = this;
    if (CardSlot == null)
    {
      return;
    }
    CardSlot.CardSlotOwner.OnPointerEnter(CardSlot, Cursor.Instance.CardHeld);
  }
  public void OnPointerExit()
  {
    /*
      Behavior determined by type of CardController that owns this slot
      Unmark this card as the one under the cursor
    */
    if (Cursor.Instance.CardUnderCursor == this)
      Cursor.Instance.CardUnderCursor = null;
    if (CardSlot == null)
    {
      return;
    }
    CardSlot.CardSlotOwner.OnPointerExit(CardSlot, Cursor.Instance.CardHeld);
  }
}
