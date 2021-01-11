using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum GameState
{
  Initializing, Playing, GameOver
}

public class GameController : MonoBehaviour
{

  /*
    Contains game logic and controls how and when the player can interact with cards, depending on the game rules.
    Contains card sprites and references to the different game-relevant entities like Deck and Hand.
  */

  public static GameState GameState;
  public DeckController Stock;
  public TalonStack Talon;

  public TableauStack[] TableauStacks;
  public FoundationStack[] FoundationStacks;
  public Transform CardPrefab;
  public Transform CardSlotPrefab;
  //Card fronts are in order from Aces to Kings, with suits in alphabetical order (Clubs->Diamonds->Hearts->Spades)
  public Sprite[] CardFronts;
  public Sprite CardBack;

  private float _timeBetweenDraws = 0.1f;

  void Awake()
  {
  }
  void Start()
  {
    Restart();
  }

  // Update is called once per frame
  void Update()
  {
  }
  public void Restart()
  {
    GameState = GameState.Initializing;
    StartCoroutine(InitializeGame(_timeBetweenDraws));
  }
  private IEnumerator InitializeGame(float timeBetweenDraws)
  {
    yield return new WaitForEndOfFrame();
    int N = TableauStacks.Length;
    GUICard card;
    for (int i = 0; i < N; i++)
    {
      for (int j = i; j < N; j++)
      {
        card = Stock.DrawCard().GetComponent<GUICard>();
        card.FaceUp = (i == j);
        TableauStacks[j].AddCard(card);
        yield return new WaitForSeconds(timeBetweenDraws);
      }
    }
    GameState = GameState.Playing;
  }
  public static void TransferCard(GUICard card, CardSlot source, CardSlot destination)
  {
    /*
      Transfer a card from one CardsController to another
    */
    source.GetComponentInParent<CardsController>().RemoveCard(card);
    destination.GetComponentInParent<CardsController>().AddCard(card);
  }
}
