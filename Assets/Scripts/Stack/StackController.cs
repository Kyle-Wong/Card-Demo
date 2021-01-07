using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : CardsController
{

  // Use this for initialization
  SlotDistributor slotDistributor;

  protected override void Awake()
  {
    base.Awake();
  }
  void Start()
  {
    slotDistributor = GetComponent<SlotDistributor>();
    slotDistributor.AddCardSpace();
  }

  // Update is called once per frame
  void Update()
  {

  }
  public override void AddCard(Transform card)
  {
    cardList.AddCard(card.GetComponent<GUICard>().CardData);
    card.GetComponent<GUICard>().currCardSlot = slotDistributor.GetCardSlot(slotDistributor.numCards - 1);
    slotDistributor.AddCardSpace();
  }
  public override void RemoveCard(Transform card)
  {
    int cardIndex = cardList.RemoveCard(card.GetComponent<GUICard>().CardData);
    slotDistributor.RemoveCardSpace(cardIndex);
  }
  public override bool CanAddCard(Transform cardSlot, Transform card)
  {
    //Last card slot is always empty
    return slotDistributor.IndexOf(cardSlot) == slotDistributor.numCards - 1;
  }
  public override bool CanRemoveCard(Transform cardSlot, Transform card)
  {
    //second-to-last card slot is the last card added
    return slotDistributor.IndexOf(cardSlot) == slotDistributor.numCards - 2;
  }

}
