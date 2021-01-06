using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{

  // Use this for initialization
  public DeckController deck;
  public HandController hand;

  public StackController[] stacks;
  public int maxHandSize;

  //Card fronts are in order from Aces to Kings, with suits in alphabetical order (Clubs->Diamonds->Hearts->Spades)
  public Sprite[] cardFronts;
  public Sprite cardBack;
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
    if (!deck.Empty())
    {
      Transform newCard = deck.DrawCard();
      hand.AddCard(newCard);
    }
  }
  public static void TransferCard(Transform card, Transform source, Transform destination)
  {
    source.GetComponentInParent<CardsController>().RemoveCard(card);
    destination.GetComponentInParent<CardsController>().AddCard(card);
  }
}
