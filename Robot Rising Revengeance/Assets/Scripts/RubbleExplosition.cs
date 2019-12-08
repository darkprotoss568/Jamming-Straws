using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbleExplosition : MonoBehaviour
{
    void OnCollisionEnter(Collider other)
    {
        if(other.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }
    }
}
