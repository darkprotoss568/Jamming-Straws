using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportZoneScript : MonoBehaviour
{
    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.position = spawnPoint.position;
        }
    }
}
