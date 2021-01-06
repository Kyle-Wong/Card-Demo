using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    print(cardData + ", " + ((cardData.value) * 4 + cardData.suit));


    return (cardData.value - 1) * 4 + cardData.suit;
  }
  public void OnDrag()
  {
    isHeld = true;
    prevPosition = moveToTarget.target;
    moveToTarget.target = FollowMouse.instance.transform;
  }
  public void OnRelease()
  {
    isHeld = false;
    moveToTarget.target = prevPosition;
  }
}
