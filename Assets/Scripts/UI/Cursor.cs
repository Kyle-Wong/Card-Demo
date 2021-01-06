using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cursor : MonoBehaviour
{

  // Use this for initialization
  private EventSystem eventSystem;
  public static Cursor instance;
  Camera mainCamera;
  private const string cardMarkerTag = "CardMarker";
  void Awake()
  {
    mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    eventSystem = EventSystem.current;
    if (instance == null)
    {
      instance = this;
    }
    else
    {
      Destroy(gameObject);
    }
  }

  // Update is called once per frame
  void Update()
  {
    Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
  }
  private List<RaycastResult> RaycastAll(PointerEventData data)
  {
    List<RaycastResult> hits = new List<RaycastResult>();
    eventSystem.RaycastAll(data, hits);
    return hits;
  }
  public Transform GetCardMarker(PointerEventData data)
  {
    /*
      Return the first CardMarker under the mouse cursor, or null if none are found
    */
    List<RaycastResult> hits = RaycastAll(data);
    foreach (RaycastResult hit in hits)
    {
      if (hit.gameObject.CompareTag(cardMarkerTag))
      {
        return hit.gameObject.transform;
      }
    }
    return null;
  }
}
