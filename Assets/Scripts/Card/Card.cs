using System.Collections;
using System.Collections.Generic;

public class Card
{
  /*
    Class that represents a card. 
    Suit is int [0-3] "Clubs", "Diamonds", "Hearts", "Spades"
    Value is int [1-13]
  */
  public static readonly string[] suitTypes = { "Clubs", "Diamonds", "Hearts", "Spades" };
  public static readonly string[] valueNames = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

  public int suit;
  public int value;

  public Card(int suit, int value)
  {
    this.suit = suit;
    this.value = value;
  }
  public string SuitType()
  {
    return suitTypes[suit];
  }
  public string ValueName()
  {
    return valueNames[value - 1];
  }
  public override string ToString()
  {
    return ValueName() + " of " + SuitType();
  }
  public bool Equals(Card other)
  {
    return this.suit == other.suit && this.value == other.value;
  }
}
