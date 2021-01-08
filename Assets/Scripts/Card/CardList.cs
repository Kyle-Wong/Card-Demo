using System.Collections;
using System.Collections.Generic;

public class CardList
{
  /*
    Mostly an extension of List.
    Contains helper functions that are commonly used
    on groups of cards.
  */
  private List<Card> _cardList;

  public CardList()
  {
    _cardList = new List<Card>();
  }
  public CardList(List<Card> cards)
  {
    _cardList = cards;
  }
  public CardList(Card[] cards)
  {
    _cardList = new List<Card>(cards);
  }
  public int IndexOf(Card card)
  {
    return _cardList.IndexOf(card);
  }
  public void AddCard(Card card)
  {
    _cardList.Add(card);
  }
  public Card RemoveCardAt(int index)
  {
    //Remove card at index and return it
    if (index < 0 || index >= _cardList.Count)
    {
      return null;
    }
    Card card = _cardList[index];
    _cardList.RemoveAt(index);
    return card;
  }
  public int RemoveCard(Card card)
  {
    //Remove card from cardList and return its index
    for (int i = 0; i < _cardList.Count; i++)
    {
      if (_cardList[i].Equals(card))
      {
        _cardList.RemoveAt(i);
        return i;
      }
    }
    return -1;
  }
  public void RearrangeCards(int fromIndex, int toIndex)
  {
    /*
      Move a card from fromIndex to toIndex, shifting all other cards left or right
    */
    if (fromIndex == toIndex)
    {
      return;
    }
    Card card = _cardList[fromIndex];
    _cardList.RemoveAt(fromIndex);
    _cardList.Insert(toIndex, card);
  }
  public override string ToString()
  {
    string s = "";
    for (int i = 0; i < _cardList.Count; i++)
    {
      s += _cardList[i] + ", ";
    }
    return s;
  }
}
