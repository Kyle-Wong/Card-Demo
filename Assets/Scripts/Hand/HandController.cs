using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{

  // Use this for initialization
  Hand hand;
  HandCardDistributor handCardDistributor;
  void Start()
  {
    hand = new Hand();
    handCardDistributor = GetComponent<HandCardDistributor>();
  }

  // Update is called once per frame

  public void AddCard(Transform card)
  {
    Transform cardMarker = handCardDistributor.AddCardSpace();
    card.GetComponent<MoveToTarget>().target = cardMarker;
    hand.AddCard(card.GetComponent<GUICard>().CardData);
  }
  public void RemoveCard(Transform card)
  {
    Card cardData = card.GetComponent<GUICard>().CardData;
    int cardIndex = hand.RemoveCard(cardData);
    handCardDistributor.RemoveCardSpace(cardIndex);
  }
}
