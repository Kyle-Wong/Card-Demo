using System.Collections;
using System.Collections.Generic;
using System;


public class Deck
{
  /*
    Class that generates a deck and deals out cards.
    Can be created with a seed for debugging purposes.
    Can be made bottomless to automatically generate a new deck once it empties.
  */

  private Stack<Card> _cardStack;
  private Random _rng;
  private bool _bottomless;
  public Deck(int numDecks = 1, bool bottomless = false, int? seed = null)
  {
    if (seed != null)
    {
      _rng = new Random((int)seed);
    }
    else
    {
      _rng = new Random();
    }
    this._cardStack = this.GenerateDeck(numDecks);
    this._bottomless = bottomless;
  }
  public Card DrawCard()
  {
    if (Empty())
    {
      return null;
    }
    Card card = _cardStack.Pop();
    if (Empty() && _bottomless)
    {
      _cardStack = GenerateDeck();
    }
    return card;
  }
  public bool Empty()
  {
    return _cardStack.Count == 0;
  }

  private Stack<Card> GenerateDeck(int numDecks = 1)
  {
    Stack<Card> newDeck = new Stack<Card>();
    for (int i = 0; i < numDecks; i++)
    {
      for (int value = 1; value <= 13; value++)
      {
        for (int suit = 0; suit < 4; suit++)
        {
          newDeck.Push(new Card(suit, value));
        }
      }
    }
    return this.ShuffleCards(newDeck);
  }
  public Stack<Card> ShuffleCards(Stack<Card> deck)
  {
    List<Card> shuffleList = new List<Card>(deck);
    for (int i = 0; i < shuffleList.Count; i++)
    {
      int randIndex = _rng.Next() % shuffleList.Count;
      Card temp = shuffleList[i];
      shuffleList[i] = shuffleList[randIndex];
      shuffleList[randIndex] = temp;
    }
    return new Stack<Card>(shuffleList);
  }
  public Stack<Card> Shuffle()
  {
    return ShuffleCards(_cardStack);
  }

}
