using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckController : MonoBehaviour
{

  // Use this for initialization
  public Transform cardPrefab;
  Transform cardsParent;
  private Image image;
  Deck deck;
  void Start()
  {
    deck = new Deck();
    cardsParent = GameObject.FindGameObjectWithTag("CardList").transform;
    image = GetComponent<Image>();
  }

  // Update is called once per frame
  void Update()
  {

  }
  public Transform DrawCard()
  {
    Card cardData = deck.DrawCard();
    if (deck.Empty())
    {
      image.enabled = false;
    }
    Transform card = Object.Instantiate(cardPrefab, transform.position, transform.rotation, cardsParent);
    card.GetComponent<GUICard>().CardData = cardData;

    return card;
  }
  public void GetNewDeck()
  {
    deck = new Deck();
    image.enabled = true;
  }
  public void Shuffle()
  {
    deck.Shuffle();
  }
  public bool Empty()
  {
    return deck.Empty();
  }
}
