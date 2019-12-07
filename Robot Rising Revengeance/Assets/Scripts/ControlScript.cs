using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{
    public bool normalMovementUnlocked = false;
    private Transform playerTransform;
    public float maxSpeed;

    public float rotateSpeed;
    private Vector3 currentDirection;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = gameObject.transform;
        currentDirection = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        HandleControls();
    }

    private void HandleControls()
    {
        float vert = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");

        if (!normalMovementUnlocked)
        {
            Debug.DrawRay(playerTransform.position, currentDirection, Color.green);

            if (hor > 0)
            {
                currentDirection = Quaternion.Euler(0, 0, rotateSpeed) * currentDirection;
            } else if (hor < 0)
            {

            }
        }

    }
}

