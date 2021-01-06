using System.Collections;
using System.Collections.Generic;

public class CardList
{

  private List<Card> cardList;

  public CardList()
  {
    cardList = new List<Card>();
  }
  public CardList(List<Card> cards)
  {
    cardList = cards;
  }
  public CardList(Card[] cards)
  {
    cardList = new List<Card>(cards);
  }
  public int IndexOf(Card card)
  {
    return cardList.IndexOf(card);
  }
  public void AddCard(Card card)
  {
    cardList.Add(card);
  }
  public Card RemoveCardAt(int index)
  {
    //Remove card at index and return it
    if (index < 0 || index >= cardList.Count)
    {
      return null;
    }
    Card card = cardList[index];
    cardList.RemoveAt(index);
    return card;
  }
  public int RemoveCard(Card card)
  {
    //Remove card from cardList and return its index
    for (int i = 0; i < cardList.Count; i++)
    {
      if (cardList[i].Equals(card))
      {
        cardList.RemoveAt(i);
        return i;
      }
    }
    return -1;
  }
  public override string ToString()
  {
    string s = "";
    for (int i = 0; i < cardList.Count; i++)
    {
      s += cardList[i] + ", ";
    }
    return s;
  }
}
