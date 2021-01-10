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

  public int Suit;
  public int Value;

  public Card(int suit, int value)
  {
    this.Suit = suit;
    this.Value = value;
  }
  public string SuitType()
  {
    return SuitTypes[Suit];
  }
  public string ValueName()
  {
    return ValueNames[Value - 1];
  }
  public override string ToString()
  {
    return ValueName() + " of " + SuitType();
  }
  public int Color(){
    //1 if red, 0 if black
    return Suit == 1 || Suit == 2 ? 1 : 0;
  }
  public bool Equals(Card other)
  {
    return this.Suit == other.Suit && this.Value == other.Value;
  }
}
