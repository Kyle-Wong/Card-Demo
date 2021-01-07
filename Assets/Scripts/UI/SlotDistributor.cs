using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotDistributor : MonoBehaviour
{

  /*
    This class controls an array of CardSlots that cards will be placed into.
    Card slots are arranged in a line. Exact spacing and whether or not it should be centered
    are public variables.
    The SlotDistributor only handles cardslot placement and generation, it should NOT know about which slots are filled 
    or which cards are placed in them.
  */
  public Vector2 spacing;
  public bool centerX;
  public bool centerY;

  private Transform cardSlotPrefab;
  private List<Transform> cardSlots;
  public int numCards
  {
    get
    {
      return cardSlots.Count;
    }
  }
  void Awake()
  {
    cardSlots = GetChildren();
    cardSlotPrefab = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().cardSlotPrefab;
  }
  void Start()
  {
  }
  // Update is called once per frame
  void Update()
  {
    //DistributeCards();
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
    /*
      Arranges all CardSlots into a straight line.
      Can grow around the center by subtracting all positions
      by half the width and/or height
    */
    float width = (cardSlots.Count - 1) * spacing.x;
    float height = (cardSlots.Count - 1) * spacing.y;
    if (!centerX)
    {
      width = 0;
    }
    if (!centerY)
    {
      height = 0;
    }
    for (int i = 0; i < cardSlots.Count; i++)
    {
      cardSlots[i].position = new Vector3(transform.position.x + (spacing.x * i - width / 2), transform.position.y + (spacing.y * i - height / 2), cardSlots[i].position.z);
    }
  }
  public void RearrangeSlots(int fromIndex, int toIndex)
  {
    /*
      Moves cardSlots at fromIndex and moves it to toIndex
    */
    if (fromIndex == toIndex)
    {
      return;
    }
    Transform cardSlot = cardSlots[fromIndex];
    cardSlots.RemoveAt(fromIndex);
    cardSlots.Insert(toIndex, cardSlot);

  }
  public Transform GetCardSlot(int index)
  {
    if (index < 0 || index >= cardSlots.Count)
    {
      Debug.LogWarning("Invalid card get: card at index " + index);
    }
    return cardSlots[index];
  }

  public int IndexOf(Transform cardSlot)
  {
    for (int i = 0; i < cardSlots.Count; i++)
    {
      if (cardSlots[i].Equals(cardSlot))
      {
        return i;
      }
    }
    return -1;
  }
  public Transform AddCardSpace()
  {
    Transform newCardSlot = Object.Instantiate(cardSlotPrefab, transform);
    cardSlots.Add(newCardSlot);
    DistributeCards();
    return newCardSlot;
  }
  public void RemoveCardSpace(int index)
  {
    if (cardSlots.Count <= 0)
    {
      return;
    }
    if (index < 0 || index >= cardSlots.Count)
    {
      Debug.LogWarning("Invalid card removal: card at index " + index);
    }

    Transform temp = cardSlots[index];
    cardSlots.RemoveAt(index);
    Destroy(temp.gameObject);
    DistributeCards();
  }
}
