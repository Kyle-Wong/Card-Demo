using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDistributor : MonoBehaviour
{

  // Use this for initialization
  public Vector2 spacing;
  public bool centerX;
  public bool centerY;

  public Transform cardMarkerPrefab;
  private List<Transform> cardMarkers;
  public int numCards
  {
    get
    {
      return cardMarkers.Count;
    }
  }
  void Awake()
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
    float width = (cardMarkers.Count - 1) * spacing.x;
    float height = (cardMarkers.Count - 1) * spacing.y;
    if (!centerX)
    {
      width = 0;
    }
    if (!centerY)
    {
      height = 0;
    }
    for (int i = 0; i < cardMarkers.Count; i++)
    {
      cardMarkers[i].position = new Vector3(transform.position.x + (spacing.x * i - width / 2), transform.position.y + (spacing.y * i - height / 2), cardMarkers[i].position.z);
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

  public int IndexOf(Transform cardMarker)
  {
    for (int i = 0; i < cardMarkers.Count; i++)
    {
      if (cardMarkers[i].Equals(cardMarker))
      {
        return i;
      }
    }
    return -1;
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
  public Transform Last()
  {
    if (cardMarkers.Count == 0)
    {
      return null;
    }
    return cardMarkers[cardMarkers.Count - 1];
  }
  public Transform First()
  {
    if (cardMarkers.Count == 0)
    {
      return null;
    }
    return cardMarkers[0];
  }
}
