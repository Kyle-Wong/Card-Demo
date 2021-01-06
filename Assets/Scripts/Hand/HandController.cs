using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : CardsController
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
  }

  // Update is called once per frame

  public override void AddCard(Transform card)
  {
    Transform cardMarker = cardDistributor.AddCardSpace();
    card.GetComponent<MoveToTarget>().target = cardMarker;
    cardGroup.AddCard(card.GetComponent<GUICard>().CardData);
  }
  public override void RemoveCard(Transform card)
  {
    Card cardData = card.GetComponent<GUICard>().CardData;
    int cardIndex = cardGroup.RemoveCard(cardData);
    cardDistributor.RemoveCardSpace(cardIndex);
  }
  public override bool CanAddCard(Transform cardMarker, Transform card)
  {
    return false; //add cards through drawing from deck
  }
  public override bool CanRemoveCard(Transform cardMarker, Transform card)
  {
    return true; //true for testing purposes
  }
}
