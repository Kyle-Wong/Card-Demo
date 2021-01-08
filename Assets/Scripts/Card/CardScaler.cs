using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScaler : MonoBehaviour
{

  /*
		Makes card bigger when held
	*/
  private GUICard _card;
  public float HeldScale;
  public float ScaleSpeed;
  private Vector3 _scaleVector;
  private Vector3 _startingScale;
  void Start()
  {
    _card = GetComponent<GUICard>();
    _scaleVector = new Vector3(HeldScale, HeldScale, 0);
    _startingScale = transform.localScale;
  }

  // Update is called once per frame
  void Update()
  {
    if (_card.IsHeld)
    {
      transform.localScale = Vector3.Lerp(transform.localScale, _scaleVector, ScaleSpeed * Time.deltaTime);
    }
    else
    {
      transform.localScale = Vector3.Lerp(transform.localScale, _startingScale, ScaleSpeed * Time.deltaTime);
    }
  }
}
