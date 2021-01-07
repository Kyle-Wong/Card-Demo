using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToSlot : MonoBehaviour
{

  // Use this for initialization
  private GUICard card;
  private Transform cursor;
  public float moveSpeed;
  public float rotationSpeed;
  void Start()
  {
    card = GetComponent<GUICard>();
    cursor = Cursor.instance.transform;
  }

  // Update is called once per frame
  void Update()
  {
    Transform cardSlot = card.currCardSlot;
    if (card.isHeld)
    {
      transform.position = Vector3.Lerp(transform.position, cursor.position, moveSpeed * Time.deltaTime);
      //transform.rotation = Quaternion.Lerp(transform.rotation, cursor.rotation, rotationSpeed * Time.deltaTime);
    }
    else if (cardSlot != null)
    {
      transform.position = Vector3.Lerp(transform.position, cardSlot.position, moveSpeed * Time.deltaTime);
      transform.rotation = Quaternion.Lerp(transform.rotation, cardSlot.rotation, rotationSpeed * Time.deltaTime);
    }

  }
}
