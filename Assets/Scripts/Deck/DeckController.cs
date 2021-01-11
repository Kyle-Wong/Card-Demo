using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckController : MonoBehaviour
{

  // Use this for initialization
  private Transform _cardPrefab;
  private Transform _cardsParent;
  private Image _image;
  private Deck _deck;
  void Start()
  {
    _deck = new Deck();
    _cardsParent = GameObject.FindGameObjectWithTag("CardList").transform;
    _image = GetComponent<Image>();
    _cardPrefab = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().CardPrefab;
  }

  // Update is called once per frame
  void Update()
  {

  }
  public Transform DrawCard()
  {
    Card cardData = _deck.DrawCard();
    if (_deck.Empty())
    {
      _image.enabled = false;
    }
    Transform card = Object.Instantiate(_cardPrefab, transform.position, transform.rotation, _cardsParent);
    card.GetComponent<GUICard>().CardData = cardData;

    return card;
  }
  public void GetNewDeck()
  {
    _deck = new Deck();
    _image.enabled = true;
  }
  public void Shuffle()
  {
    _deck.Shuffle();
  }
  public bool Empty()
  {
    return _deck.Empty();
  }
}
