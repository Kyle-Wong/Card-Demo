using System.Collections;
using System.Collections.Generic;

public class Card
{
  /*
    Class that represents a card. 
    Suit is int [0-3] "Clubs", "Diamonds", "Hearts", "Spades"
    Value is int [1-13]
  */
  public static readonly string[] SuitTypes = { "Clubs", "Diamonds", "Hearts", "Spades" };
  public static readonly string[] ValueNames = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

  public int _suit;
  public int _value;

  public Card(int suit, int value)
  {
    this._suit = suit;
    this._value = value;
  }
  public string SuitType()
  {
    return SuitTypes[_suit];
  }
  public string ValueName()
  {
    return ValueNames[_value - 1];
  }
  public override string ToString()
  {
    return ValueName() + " of " + SuitType();
  }
  public bool Equals(Card other)
  {
    return this._suit == other._suit && this._value == other._value;
  }
}
