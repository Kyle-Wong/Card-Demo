using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotDistributor : MonoBehaviour
{

  /*
    This class controls an array of CardSlots that cards will be placed into.
    Card slots are arranged in a line. Exact spacing and whether or not it should be centered
    are public variables.
    The SlotDistributor only handles cardslot placement and generation, it does not
    care about the identity of cards.
  */
  public Vector2 Spacing;
  public bool CenterX;
  public bool CenterY;

  private Transform _cardSlotPrefab;
  private List<Transform> _cardSlots;
  public int SlotCount
  {
    get
    {
      return _cardSlots.Count;
    }
  }
  void Awake()
  {
    _cardSlots = GetChildren();
    _cardSlotPrefab = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().CardSlotPrefab;
  }
  void OnEnable()
  {
  }
  void Start()
  {
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
    /*
      Arranges all CardSlots into a straight line.
      Can grow around the center by subtracting all positions
      by half the width and/or height
    */
    float width = (_cardSlots.Count - 1) * Spacing.x;
    float height = (_cardSlots.Count - 1) * Spacing.y;
    if (!CenterX)
    {
      width = 0;
    }
    if (!CenterY)
    {
      height = 0;
    }
    for (int i = 0; i < _cardSlots.Count; i++)
    {
      _cardSlots[i].position = new Vector3(transform.position.x + (Spacing.x * i - width / 2), transform.position.y + (Spacing.y * i - height / 2), _cardSlots[i].position.z);
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
    Transform cardSlot = _cardSlots[fromIndex];
    _cardSlots.RemoveAt(fromIndex);
    _cardSlots.Insert(toIndex, cardSlot);
    DistributeCards();
  }
  public Transform GetCardSlot(int index)
  {
    if (index < 0 || index >= _cardSlots.Count)
    {
      Debug.LogWarning("Invalid card get: card at index " + index);
    }
    return _cardSlots[index];
  }

  public int IndexOf(Transform cardSlot)
  {
    for (int i = 0; i < _cardSlots.Count; i++)
    {
      if (_cardSlots[i].Equals(cardSlot))
      {
        return i;
      }
    }
    return -1;
  }
  public Transform AddCardSpace()
  {
    Transform newCardSlot = Object.Instantiate(_cardSlotPrefab, transform);
    _cardSlots.Add(newCardSlot);
    DistributeCards();
    return newCardSlot;
  }
  public void RemoveCardSpace(int index)
  {
    if (_cardSlots.Count <= 0)
    {
      return;
    }
    if (index < 0 || index >= _cardSlots.Count)
    {
      Debug.LogWarning("Invalid card removal: card at index " + index);
    }

    Transform temp = _cardSlots[index];
    _cardSlots.RemoveAt(index);
    Destroy(temp.gameObject);
    DistributeCards();
  }
}
