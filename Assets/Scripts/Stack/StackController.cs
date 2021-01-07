using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : CardsController
{

  // Use this for initialization
  CardDistributor cardDistributor;

  protected override void Awake()
  {
    base.Awake();
  }
  void Start()
  {
    cardDistributor = GetComponent<CardDistributor>();
    cardDistributor.AddCardSpace();
  }

  // Update is called once per frame
  void Update()
  {

  }
  public override void AddCard(Transform card)
  {
    cardList.AddCard(card.GetComponent<GUICard>().CardData);
    card.GetComponent<GUICard>().currCardMarker = cardDistributor.GetCardMarker(cardDistributor.numCards - 1);
    cardDistributor.AddCardSpace();
  }
  public override void RemoveCard(Transform card)
  {
    int cardIndex = cardList.RemoveCard(card.GetComponent<GUICard>().CardData);
    cardDistributor.RemoveCardSpace(cardIndex);
  }
  public override bool CanAddCard(Transform cardMarker, Transform card)
  {
    return cardDistributor.IndexOf(cardMarker) == cardDistributor.numCards - 1;
  }
  public override bool CanRemoveCard(Transform cardMarker, Transform card)
  {
    return cardDistributor.IndexOf(cardMarker) == cardDistributor.numCards - 2;
  }

}
