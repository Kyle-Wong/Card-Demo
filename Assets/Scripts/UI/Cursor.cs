using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cursor : MonoBehaviour
{

  // Use this for initialization
  private EventSystem eventSystem;
  public static Cursor instance;
  Camera mainCamera;
  private const string cardSlotTag = "CardSlot";


  [HideInInspector]
  public Transform cardHeld;

  void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
    else
    {
      Destroy(gameObject);
    }
    mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    eventSystem = EventSystem.current;
    cardHeld = null;
  }

  // Update is called once per frame
  void Update()
  {
    Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
  }
  public void PickUpCard(Transform card)
  {
    cardHeld = card;
  }
  public void DropCard(PointerEventData data, Transform prevSlot, Transform card)
  {
    /*
      Raycast from mouse cursor in order to check if there is a valid cardSlot to place
      the card into. If there is such a slot, transfer the card from its last owner to 
      the new owner.
    */
    cardHeld = null;
    Transform cardSlot = GetCardSlot((PointerEventData)data);
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
    eventSystem.RaycastAll(data, hits);
    return hits;
  }
  public Transform GetCardSlot(PointerEventData data)
  {
    /*
      Return the first cardSlot under the mouse cursor, or null if none are found
    */
    List<RaycastResult> hits = RaycastAll(data);
    foreach (RaycastResult hit in hits)
    {
      if (hit.gameObject.CompareTag(cardSlotTag))
      {
        return hit.gameObject.transform;
      }
    }
    return null;
  }
  public bool IsHoldingCard()
  {
    return cardHeld != null;
  }
}
