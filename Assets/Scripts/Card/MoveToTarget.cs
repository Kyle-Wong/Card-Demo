using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{

  // Use this for initialization
  private GUICard card;
  public float moveSpeed;
  public float rotationSpeed;
  void Start()
  {
    card = GetComponent<GUICard>();
  }

  // Update is called once per frame
  void Update()
  {
    Transform cardMarker = card.currCardMarker;
    if (cardMarker != null)
    {
      Vector3 tocardMarker = (cardMarker.position - transform.position).normalized;
      transform.position = Vector3.Lerp(transform.position, cardMarker.position, moveSpeed * Time.deltaTime);
      transform.rotation = Quaternion.Lerp(transform.rotation, cardMarker.rotation, rotationSpeed * Time.deltaTime);
    }

  }
}
