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

  private Stack<Card> cardStack;
  private Random rng;
  private bool bottomless;
  public Deck(int numDecks = 1, bool bottomless = false, int? seed = null)
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
    this.bottomless = bottomless;
  }
  public Card DrawCard()
  {
    if (Empty())
    {
      return null;
    }
    Card card = cardStack.Pop();
    if (Empty() && bottomless)
    {
      cardStack = GenerateDeck();
    }
    return card;
  }
  public bool Empty()
  {
    return cardStack.Count == 0;
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
