using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{

  /*
    Contains game logic and controls how and when the player can interact with cards, depending on the game rules.
    Contains card sprites and references to the different game-relevant entities like Deck and Hand.
  */
  public DeckController Deck;
  public HandController Hand;

  public StackController[] Stacks;
  public Transform CardPrefab;
  public Transform CardSlotPrefab;
  public int MaxHandSize;

  //Card fronts are in order from Aces to Kings, with suits in alphabetical order (Clubs->Diamonds->Hearts->Spades)
  public Sprite[] CardFronts;
  public Sprite CardBack;
  void Awake()
  {
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      DrawCard();
    }
  }
  private void DrawCard()
  {
    /*
      Add a card from the Deck to Hand
    */
    if (!Deck.Empty())
    {
      Transform newCard = Deck.DrawCard();
      Hand.AddCard(newCard);
    }
  }
  public static void TransferCard(Transform card, Transform source, Transform destination)
  {
    /*
      Transfer a card from one CardsController to another
    */
    source.GetComponentInParent<CardsController>().RemoveCard(card);
    destination.GetComponentInParent<CardsController>().AddCard(card);
  }
}
