using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCardDistributor : MonoBehaviour
{
  /*
		Handles the left/right position of cards in the player's hand
		and makes space for new ones as needed.
	*/
  // Use this for initialization
  public float spacing;
  public Transform cardMarkerPrefab;
  private List<Transform> cardMarkers;
  public int handSize
  {
    get
    {
      return cardMarkers.Count;
    }
  }
  void Start()
  {
    cardMarkers = GetChildren();

  }

  // Update is called once per frame
  void Update()
  {
    DistributeCards();
  }
  private List<Transform> GetChildren()
  {
    List<Transform> children = new List<Transform>();
    foreach (Transform child in transform)
      children.Add(child);
    return children;
  }
  private void DistributeCards()
  {
    float width = (cardMarkers.Count - 1) * spacing;
    float parentX = transform.position.x;
    for (int i = 0; i < cardMarkers.Count; i++)
    {
      Vector3 cardPosition = cardMarkers[i].position;
      cardMarkers[i].position = new Vector3(parentX + (spacing * i - width / 2), cardPosition.y, cardPosition.z);
    }
  }

  public Transform GetCardMarker(int index)
  {
    if (index < 0 || index >= cardMarkers.Count)
    {
      Debug.LogWarning("Invalid card get: card at index " + index);
    }
    return cardMarkers[index];
  }
  public Transform AddCardSpace()
  {
    Transform newCardMarker = Object.Instantiate(cardMarkerPrefab, transform);
    cardMarkers.Add(newCardMarker);
    DistributeCards();
    return newCardMarker;
  }
  public void RemoveCardSpace(int index)
  {
    if (cardMarkers.Count <= 0)
    {
      return;
    }
    if (index < 0 || index >= cardMarkers.Count)
    {
      Debug.LogWarning("Invalid card removal: card at index " + index);
    }

    Transform temp = cardMarkers[index];
    cardMarkers.RemoveAt(index);
    Destroy(temp.gameObject);
    DistributeCards();
  }
}
