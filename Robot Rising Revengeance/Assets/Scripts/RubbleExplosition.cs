using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbleExplosition : MonoBehaviour
{
    void OnCollision(other collider)
    {
        if(other.tag = "projectile")
        {
            Destory(gameObject);
        }
    }
}
