using System.Collections;
using System.Collections.Generic;

public class Hand
{

  // Use this for initialization
  private List<Card> hand;

  public Hand()
  {
    hand = new List<Card>();
  }
  public Hand(List<Card> cards)
  {
    hand = cards;
  }
  public Hand(Card[] cards)
  {
    hand = new List<Card>(cards);
  }
  public void AddCard(Card card)
  {
    hand.Add(card);
  }
  public Card RemoveCardAt(int index)
  {
    //Remove card at index and return it
    if (index < 0 || index >= hand.Count)
    {
      return null;
    }
    Card card = hand[index];
    hand.RemoveAt(index);
    return card;
  }
  public int RemoveCard(Card card)
  {
    //Remove card from hand and return its index
    for (int i = 0; i < hand.Count; i++)
    {
      if (hand[i].Equals(card))
      {
        hand.RemoveAt(i);
        return i;
      }
    }
    return -1;
  }
  public override string ToString()
  {
    string s = "";
    for (int i = 0; i < hand.Count; i++)
    {
      s += hand[i] + ", ";
    }
    return s;
  }
}
