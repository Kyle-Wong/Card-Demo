using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{

  // Use this for initialization
  Deck deck;
  Transform deckObject;
  Transform cardsParent;
  public int maxHandSize;
  Hand hand;
  HandCardDistributor handCardDistributor;

  public Transform cardTransform;
  //Card fronts are in order from Aces to Kings, with suits in alphabetical order (Clubs->Diamonds->Hearts->Spades)
  public Sprite[] cardFronts;
  public Sprite cardBack;
  void Awake()
  {
    deck = new Deck();
    hand = new Hand();
    handCardDistributor = GameObject.FindGameObjectWithTag("Hand").GetComponent<HandCardDistributor>();
    deckObject = GameObject.FindGameObjectWithTag("Deck").transform;
    cardsParent = GameObject.FindGameObjectWithTag("CardList").transform;
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
			1. Draw card from deck
			2. add card to hand
			3. make space for new card in player's hand
			4. make new GUICard at the deck's location
			5. link the GUICard to the cardMarker in the player's hand
		*/
    if (!deck.Empty())
    {
      Card newCard = deck.DrawCard();
      hand.AddCard(newCard);
      Transform cardMarker = handCardDistributor.AddCardSpace();
      Transform card = Object.Instantiate(cardTransform, deckObject.position, deckObject.rotation, cardsParent);
      card.GetComponent<MoveToTarget>().target = cardMarker;
      card.GetComponent<GUICard>().CardData = newCard;
    }
  }
}
