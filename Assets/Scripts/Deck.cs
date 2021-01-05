using System.Collections;
using System.Collections.Generic;
using System;


public class Deck
{

  // Use this for initialization
  private Stack<Card> cardStack;
  private Random rng;
  public Deck(int numDecks)
  {
    this.cardStack = this.GenerateDeck(numDecks);
  }
  public Deck(int numDecks, int seed)
  {
    rng = new Random(seed);
    this.cardStack = this.GenerateDeck(numDecks);
  }
  // Update is called once per frame
  public Card DrawCard()
  {
    return cardStack.Pop();
  }

  private Stack<Card> GenerateDeck(int numDecks)
  {
    Stack<Card> newDeck = new Stack<Card>();
    for (int i = 0; i < numDecks; i++)
    {
      for (int value = 0; value < 13; value++)
      {
        for (int suit = 0; suit < 4; suit++)
        {
          newDeck.Push(new Card(suit, value));
        }
      }
    }

    return this.Shuffle(newDeck);
  }
  public Stack<Card> Shuffle(Stack<Card> deck)
  {
    List<Card> shuffleList = new List<Card>(deck);
    for (int i = 0; i < shuffleList.Count; i++)
    {
      int randIndex = rng.Next();
      Card temp = shuffleList[i];
      shuffleList[i] = shuffleList[randIndex];
      shuffleList[randIndex] = temp;
    }
    return new Stack<Card>(shuffleList);
  }


}
