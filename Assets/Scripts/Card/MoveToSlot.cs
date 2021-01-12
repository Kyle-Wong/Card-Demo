using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToSlot : MonoBehaviour
{

  // Use this for initialization
  private GUICard _card;
  private Transform _cursor;
  public float MoveSpeed;
  void Start()
  {
    _card = GetComponent<GUICard>();
    _cursor = Cursor.Instance.transform;
  }

  // Update is called once per frame
  void Update()
  {
    Transform cardSlot = _card.CardSlot.transform;
    if (_card.IsHeld)
    {
      transform.position = Vector3.Lerp(transform.position, _cursor.position, MoveSpeed * Time.deltaTime);
    }
    else if (cardSlot != null)
    {
      transform.position = Vector3.Lerp(transform.position, cardSlot.position, MoveSpeed * Time.deltaTime);
    }

  }
}
