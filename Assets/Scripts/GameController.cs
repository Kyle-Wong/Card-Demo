using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{

  // Use this for initialization
  DeckController deck;
  public int maxHandSize;
  HandController hand;

  //Card fronts are in order from Aces to Kings, with suits in alphabetical order (Clubs->Diamonds->Hearts->Spades)
  public Sprite[] cardFronts;
  public Sprite cardBack;
  void Awake()
  {
    hand = GameObject.FindGameObjectWithTag("Hand").GetComponent<HandController>();
    deck = GameObject.FindGameObjectWithTag("Deck").GetComponent<DeckController>();
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
}
