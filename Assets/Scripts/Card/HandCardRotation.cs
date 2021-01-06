using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCardRotation : MonoBehaviour
{

  // Use this for initialization
  private Transform target;
  void Start()
  {
    target = GameObject.FindGameObjectWithTag("CardRotationReference").transform;
  }

  // Update is called once per frame
  void Update()
  {
    Vector3 diff = target.position - transform.position;
    float z = 90 + Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0.0f, 0.0f, z);
  }
}
