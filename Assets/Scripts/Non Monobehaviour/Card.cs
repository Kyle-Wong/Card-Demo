using System.Collections;
using System.Collections.Generic;

public class Card
{

  // Use this for initialization
  public static readonly string[] suitTypes = { "Hearts", "Diamonds", "Clubs", "Spades" };
  public static readonly string[] valueNames = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
  private int suit;
  private int value;

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
    return valueNames[value];
  }
  public bool Equals(Card other)
  {
    return this.suit == other.suit && this.value == other.value;
  }
}
