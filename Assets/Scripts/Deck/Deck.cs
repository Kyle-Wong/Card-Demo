using System.Collections;
using System.Collections.Generic;
using System;


public class Deck
{

  // Use this for initialization
  private Stack<Card> cardStack;
  private Random rng;

  public Deck(int numDecks = 1, int? seed = null)
  {
    if (seed != null)
    {
      rng = new Random((int)seed);
    }
    else
    {
      rng = new Random();
    }
    this.cardStack = this.GenerateDeck(numDecks);
  }
  // Update is called once per frame
  public Card DrawCard()
  {
    if (Empty())
    {
      return null;
    }
    return cardStack.Pop();
  }
  public bool Empty()
  {
    return cardStack.Count == 0;
  }

  private Stack<Card> GenerateDeck(int numDecks)
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
      int randIndex = rng.Next() % shuffleList.Count;
      Card temp = shuffleList[i];
      shuffleList[i] = shuffleList[randIndex];
      shuffleList[randIndex] = temp;
    }
    return new Stack<Card>(shuffleList);
  }
  public Stack<Card> Shuffle()
  {
    return ShuffleCards(cardStack);
  }

}
