using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScaler : MonoBehaviour
{

  /*
		Makes card bigger when held
	*/
  private GUICard card;
  public float heldScale;
  public float scaleSpeed;
  private Vector3 scaleVector;
  private Vector3 startingScale;
  void Start()
  {
    card = GetComponent<GUICard>();
    scaleVector = new Vector3(heldScale, heldScale, 0);
    startingScale = transform.localScale;
  }

  // Update is called once per frame
  void Update()
  {
    if (card.isHeld)
    {
      transform.localScale = Vector3.Lerp(transform.localScale, scaleVector, scaleSpeed * Time.deltaTime);
    }
    else
    {
      transform.localScale = Vector3.Lerp(transform.localScale, startingScale, scaleSpeed * Time.deltaTime);
    }
  }
}
