using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GUICard : MonoBehaviour
{

  // Use this for initialization
  GameController gameController;
  private MoveToTarget moveToTarget;
  private Card cardData;
  private bool isHeld;
  private Transform prevPosition;
  public Card CardData
  {
    get
    {
      return cardData;
    }
    set
    {
      cardData = value;
      UpdateCard(value);
    }
  }
  private Image image;
  public bool faceUp = true;
  void Awake()
  {
    image = transform.GetComponent<Image>();
    gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    moveToTarget = GetComponent<MoveToTarget>();
    isHeld = false;
  }

  // Update is called once per frame
  void Update()
  {

  }
  private void UpdateCard(Card card)
  {
    if (faceUp)
    {
      image.sprite = gameController.cardFronts[ImageCode()];
    }
    else
    {
      image.sprite = gameController.cardBack;
    }
  }
  private int ImageCode()
  {
    return (cardData.value - 1) * 4 + cardData.suit;
  }
  public void OnDrag()
  {
    if (!moveToTarget.target.GetComponentInParent<CardsController>().CanRemoveCard(moveToTarget.target, transform))
    {
      return;
    }
    isHeld = true;
    prevPosition = moveToTarget.target;
    moveToTarget.target = Cursor.instance.transform;
    transform.SetAsLastSibling();
  }
  public void OnRelease(BaseEventData data)
  {
    if (!isHeld)
    {
      return;
    }
    isHeld = false;
    Transform cardMarker = Cursor.instance.GetCardMarker((PointerEventData)data);
    if (cardMarker != null)
    {
      CardsController cc = cardMarker.GetComponentInParent<CardsController>();
      if (cc.CanAddCard(cardMarker, transform))
      {
        GameController.TransferCard(transform, prevPosition, cardMarker);
        return;
      }
    }
    moveToTarget.target = prevPosition;
  }
}
