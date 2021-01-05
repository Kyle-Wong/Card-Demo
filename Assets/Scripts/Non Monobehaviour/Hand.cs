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
  public Card RemoveCard(int index)
  {
    if (index < 0 || index >= hand.Count)
    {
      return null;
    }
    Card card = hand[index];
    hand.RemoveAt(index);
    return card;
  }
  public Card RemoveCard(Card card)
  {
    for (int i = 0; i < hand.Count; i++)
    {
      if (hand[i].Equals(card))
      {
        Card temp = hand[i];
        hand.RemoveAt(i);
        return temp;
      }
    }
    return null;
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
