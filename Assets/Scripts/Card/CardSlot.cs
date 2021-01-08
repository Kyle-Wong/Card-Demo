using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlot : MonoBehaviour
{
  /*
		Card Slots are essentially places where cards can potentially be placed.
		Whenever a card is given a reference to a CardSlot, it rapidly moves towards it.
		Depending on the logic in the CardSlot's owner, a card may or may not be placed
		in a given CardSlot.
	*/
  public CardsController CardSlotOwner;
  private RectTransform _rectTransform;
  [HideInInspector]
  public GUICard _card;
  void Awake()
  {
    _rectTransform = GetComponent<RectTransform>();
  }
  void Start()
  {
    CardSlotOwner = GetComponentInParent<CardsController>();
  }

  // Update is called once per frame
  void Update()
  {

  }
  void OnDrawGizmos()
  {
    /*
      Draw bounding box for card slot
    */
    Gizmos.color = Color.green;
    if (_rectTransform == null)
    {
      _rectTransform = GetComponent<RectTransform>();
    }
    Vector3[] corners = new Vector3[4];
    _rectTransform.GetWorldCorners(corners);
    Gizmos.DrawLine(corners[0], corners[1]);
    Gizmos.DrawLine(corners[1], corners[2]);
    Gizmos.DrawLine(corners[2], corners[3]);
    Gizmos.DrawLine(corners[3], corners[0]);
  }

}
