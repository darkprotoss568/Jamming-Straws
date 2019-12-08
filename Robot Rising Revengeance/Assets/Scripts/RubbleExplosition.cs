using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbleExplosition : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }
    }
}
