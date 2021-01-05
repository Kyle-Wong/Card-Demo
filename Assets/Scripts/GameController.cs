using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

  // Use this for initialization
  Deck deck;
  public Transform deckObject;
  public int maxHandSize;
  Hand hand;
  public HandCardDistributor handCardDistributor;
  void Awake()
  {
    deck = new Deck();
    hand = new Hand();
  }

  // Update is called once per frame
  void Update()
  {

  }
  private void DrawCard()
  {
    if (!deck.Empty())
    {
      Card newCard = deck.DrawCard();
      hand.AddCard(newCard);

    }
  }
}
