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
    _slotDistributor.AddCardSlot();
  }

  // Update is called once per frame
  void Update()
  {

  }
  public override void AddCard(GUICard card)
  {
    CardList.AddCard(card.GetComponent<GUICard>().CardData);
    card.CardSlot = _slotDistributor.GetCardSlot(_slotDistributor.SlotCount - 1);
    _slotDistributor.AddCardSlot();
  }
  public override void RemoveCard(GUICard card)
  {
    int cardIndex = CardList.RemoveCard(card.CardData);
    _slotDistributor.RemoveCardSpace(cardIndex);
  }
  public override bool CanAddCard(CardSlot cardSlot, GUICard card)
  {
    //Last card slot is always empty
    return _slotDistributor.IndexOf(cardSlot) == _slotDistributor.SlotCount - 1;
  }
  public override bool CanRemoveCard(CardSlot cardSlot, GUICard card)
  {
    //second-to-last card slot is the last card added
    return _slotDistributor.IndexOf(cardSlot) == _slotDistributor.SlotCount - 2;
  }
  public virtual CardSlot GetOpenSlot()
  {
    return _slotDistributor.GetCardSlot(_slotDistributor.SlotCount - 1);
  }
}
