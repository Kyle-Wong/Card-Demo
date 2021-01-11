using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cursor : MonoBehaviour
{
  /*
    Singleton Class
    Contains logic used by the mouse cursor when interacting with the game board and the cards.
    Matches the mouse cursor's position each frame.
  */
  private EventSystem _eventSystem;
  public static Cursor Instance;
  private Camera _mainCamera;
  private const string CARD_SLOT_TAG = "CardSlot";


  [HideInInspector]
  public GUICard CardHeld;
  [HideInInspector]
  public GUICard CardUnderCursor;

  void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    }
    else
    {
      Destroy(gameObject);
    }
    _mainCamera = Camera.main;
    _eventSystem = EventSystem.current;
    CardHeld = null;
  }

  // Update is called once per frame
  void Update()
  {
    Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
    transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
  }
  public void PickUpCard(GUICard card)
  {
    CardHeld = card;
  }
  public void DropCard(PointerEventData data, CardSlot prevSlot, GUICard card)
  {
    /*
      Raycast from mouse cursor in order to check if there is a valid cardSlot to place
      the card into. If there is such a slot, transfer the card from its last owner to 
      the new owner.
    */
    CardHeld = null;
    CardSlot cardSlot = GetCardSlot((PointerEventData)data);
    if (cardSlot != null)
    {
      CardsController cc = cardSlot.GetComponentInParent<CardsController>();
      if (cc.CanAddCard(cardSlot, card))
      {
        GameController.TransferCard(card, prevSlot, cardSlot);
        return;
      }
    }

  }
  private List<RaycastResult> RaycastAll(PointerEventData data)
  {
    List<RaycastResult> hits = new List<RaycastResult>();
    _eventSystem.RaycastAll(data, hits);
    return hits;
  }
  public CardSlot GetCardSlot(PointerEventData data)
  {
    /*
      Return the first cardSlot under the mouse cursor, or null if none are found
    */
    List<RaycastResult> hits = RaycastAll(data);
    foreach (RaycastResult hit in hits)
    {
      if (hit.gameObject.CompareTag(CARD_SLOT_TAG))
      {
        return hit.gameObject.GetComponent<CardSlot>();
      }
    }
    return null;
  }
  public bool IsHoldingCard()
  {
    return CardHeld != null;
  }
}
