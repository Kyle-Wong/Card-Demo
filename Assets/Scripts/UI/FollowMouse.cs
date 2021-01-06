using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

  // Use this for initialization
  public static FollowMouse instance;
  Camera mainCamera;
  void Awake()
  {
    mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    if (instance == null)
    {
      instance = this;
    }
  }

  // Update is called once per frame
  void Update()
  {
    Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
  }
}
