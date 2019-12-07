using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltScript : MonoBehaviour
{
    public GameObject belt;
    public Transform endpoint;
    public Transform beginpoint;
    public float speed;


    void OnTriggerStay(Collider other)
    {
        Vector3 direction = (endpoint.position - beginpoint.position).normalized;

        other.transform.position += direction * speed * Time.deltaTime;
    }
}
