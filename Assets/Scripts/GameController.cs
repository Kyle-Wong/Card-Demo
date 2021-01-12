using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

  public List<TableauStack> TableauStacks;
  public List<FoundationStack> FoundationStacks;
  public Transform CardPrefab;
  public Transform CardSlotPrefab;
  //Card fronts are in order from Aces to Kings, with suits in alphabetical order (Clubs->Diamonds->Hearts->Spades)
  public Sprite[] CardFronts;
  public Sprite CardBack;

  private float _timeBetweenDraws = 0.1f;
  private List<CardSlot> _highlightedSlots;
  public Color ValidMoveColor;

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
    switch (GameState)
    {
      case GameState.Playing:
        HighlightValidMoves();
        break;
    }
  }
  public void Restart()
  {
    GameState = GameState.Initializing;
    _highlightedSlots = null;
    StartCoroutine(InitializeGame(_timeBetweenDraws));
  }
  private IEnumerator InitializeGame(float timeBetweenDraws)
  {
    yield return new WaitForEndOfFrame();
    int N = TableauStacks.Count;
    GUICard card;
    for (int i = 0; i < N; i++)
    {
      for (int j = i; j < N; j++)
      {
        card = Stock.DrawCard().GetComponent<GUICard>();
        card.SetFaceUp(i == j, true);
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
  public List<CardSlot> GetValidMoves(GUICard heldCard)
  {

    List<CardSlot> validMoves = new List<CardSlot>();
    if (heldCard == null || !heldCard.CardSlot.CardSlotOwner.CanRemoveCard(heldCard.CardSlot, heldCard))
    {
      return validMoves;
    }

    List<CardList> tableauCards = TableauStacks.Select(s => s.CardList).ToList();
    List<CardList> foundationCards = FoundationStacks.Select(s => s.CardList).ToList();
    List<(Solitaire.Location, int)> actions = Solitaire.GetCardActions(heldCard.CardData, tableauCards, foundationCards);


    foreach ((Solitaire.Location loc, int i) in actions)
    {
      switch (loc)
      {
        case Solitaire.Location.Tableau:
          validMoves.Add(TableauStacks[i].GetOpenSlot());
          break;
        case Solitaire.Location.Foundation:
          validMoves.Add(FoundationStacks[i].GetOpenSlot());
          break;
      }
    }

    return validMoves;
  }
  private void HighlightValidMoves()
  {
    if (Cursor.Instance.CardUnderCursor != null || Cursor.Instance.IsHoldingCard())
    {
      if (_highlightedSlots == null)
      {
        if (Cursor.Instance.IsHoldingCard())
          _highlightedSlots = GetValidMoves(Cursor.Instance.CardHeld);
        else
          _highlightedSlots = GetValidMoves(Cursor.Instance.CardUnderCursor);


        foreach (CardSlot cs in _highlightedSlots)
        {
          cs.transform.GetChild(0).GetComponent<Image>().color = ValidMoveColor;
        }
      }

    }
    else
    {
      if (_highlightedSlots != null)
      {
        foreach (CardSlot cs in _highlightedSlots)
        {
          cs.transform.GetChild(0).GetComponent<Image>().color = Color.clear;
        }
        _highlightedSlots = null;
      }
    }
  }
}
