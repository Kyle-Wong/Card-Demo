using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMarker : MonoBehaviour
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
    Transform cardMarker = card.currCardMarker;
    if (card.isHeld)
    {
      transform.position = Vector3.Lerp(transform.position, cursor.position, moveSpeed * Time.deltaTime);
      transform.rotation = Quaternion.Lerp(transform.rotation, cursor.rotation, rotationSpeed * Time.deltaTime);
    }
    else if (cardMarker != null)
    {
      transform.position = Vector3.Lerp(transform.position, cardMarker.position, moveSpeed * Time.deltaTime);
      transform.rotation = Quaternion.Lerp(transform.rotation, cardMarker.rotation, rotationSpeed * Time.deltaTime);
    }

  }
}
