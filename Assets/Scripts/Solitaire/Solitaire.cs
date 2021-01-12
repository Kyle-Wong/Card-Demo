using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solitaire
{
  /*
    Contains the rules of solitaire, accessed via static methods
  */
  public enum Location
  {
    Tableau, Stock, Talon, Foundation
  }
  public static bool ValidMove(Card card, CardList cardsAtDestination, Location destinationType)
  {
    /*
      Return boolean for if a given card can be placed at a given destination
    */
    Card topCard;
    switch (destinationType)
    {
      case Location.Foundation:
        /*
            2 cases:
            1. Foundation Stack is empty. Can be started by any Ace
            2. Foundation Stack is not empty. Only card of the same suit and exactly one value higher is allowed
        */
        topCard = cardsAtDestination.Last();
        if (topCard == null)
        {
          return card.ValueName() == "Ace";
        }
        else
        {
          return card.Suit == topCard.Suit && card.Value == topCard.Value + 1;
        }
      case Location.Tableau:
        /*
            2 cases:
            1. Tableau Stack is empty. Can be started by any King
            2. Tableau Stack is not empty. Card must be 1 value lower and different color
        */
        topCard = cardsAtDestination.Last();
        if (topCard == null)
        {
          return card.ValueName() == "King";
        }
        else
        {
          return card.Color() != topCard.Color() && card.Value == topCard.Value - 1;
        }
      default:
        //Cards cannot be added to the Talon or Stock
        return false;
    }
  }
  public static List<(Location, int)> GetCardActions(Card card, List<CardList> tableauStacks, List<CardList> foundationStacks)
  {
    List<(Location, int)> validMoves = new List<(Location, int)>();
    for (int i = 0; i < tableauStacks.Count; i++)
    {
      if (Solitaire.ValidMove(card, tableauStacks[i], Solitaire.Location.Tableau))
      {
        validMoves.Add((Location.Tableau, i));
      }
    }
    for (int i = 0; i < foundationStacks.Count; i++)
    {
      if (Solitaire.ValidMove(card, foundationStacks[i], Solitaire.Location.Foundation))
      {
        validMoves.Add((Location.Foundation, i));
      }
    }
    return validMoves;
  }
  public static bool HasActions(List<CardList> tableauStacks, List<CardList> foundationStacks, CardList talonStack)
  {
    foreach (CardList ts in tableauStacks)
    {
      if (GetCardActions(ts.Last(), tableauStacks, foundationStacks).Count > 0)
      {
        return true;
      }
    }

    if (GetCardActions(talonStack.Last(), tableauStacks, foundationStacks).Count > 0)
    {
      return true;
    }
    return false;
  }
}
