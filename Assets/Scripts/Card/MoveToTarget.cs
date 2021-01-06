using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{

  // Use this for initialization
  public Transform target;
  public float moveSpeed;
  public float rotationSpeed;
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (target != null)
    {
      Vector3 toTarget = (target.position - transform.position).normalized;
      transform.position = Vector3.Lerp(transform.position, target.position, moveSpeed * Time.deltaTime);
      transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotationSpeed * Time.deltaTime);
    }

  }
}
