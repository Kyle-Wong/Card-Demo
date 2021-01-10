using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : CardsController
{

  // Use this for initialization
  protected SlotDistributor _slotDistributor;

  protected override void Awake()
  {
    base.Awake();
  }
  void Start()
  {
    _slotDistributor = GetComponent<SlotDistributor>();
    _slotDistributor.AddCardSpace();
  }

  // Update is called once per frame
  void Update()
  {

  }
  public override void AddCard(Transform card)
  {
    _cardList.AddCard(card.GetComponent<GUICard>().Card);
    card.GetComponent<GUICard>().CardSlot = _slotDistributor.GetCardSlot(_slotDistributor.SlotCount - 1);
    _slotDistributor.AddCardSpace();
  }
  public override void RemoveCard(Transform card)
  {
    int cardIndex = _cardList.RemoveCard(card.GetComponent<GUICard>().Card);
    _slotDistributor.RemoveCardSpace(cardIndex);
  }
  public override bool CanAddCard(Transform cardSlot, Transform card)
  {
    //Last card slot is always empty
    return _slotDistributor.IndexOf(cardSlot) == _slotDistributor.SlotCount - 1;
  }
  public override bool CanRemoveCard(Transform cardSlot, Transform card)
  {
    //second-to-last card slot is the last card added
    return _slotDistributor.IndexOf(cardSlot) == _slotDistributor.SlotCount - 2;
  }

}
