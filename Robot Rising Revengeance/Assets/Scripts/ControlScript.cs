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

            if (hor > 0)
            {
                currentDirection = Quaternion.Euler(0, 0, -rotateSpeed) * currentDirection;
            }
            else if (hor < 0)
            {
                currentDirection = Quaternion.Euler(0, 0, rotateSpeed) * currentDirection;
            }

            if (vert > 0)
            {
                playerTransform.position += maxSpeed * (currentDirection) * Time.deltaTime;
            }
            else if (vert < 0)
            {
                playerTransform.position -= maxSpeed * (currentDirection) * Time.deltaTime;
            }

            playerTransform.eulerAngles = new Vector3(0, 0, Vector3.SignedAngle(currentDirection, new Vector3(0, 1, 0), -Vector3.forward));
        }
        else
        {
            if (vert != 0 || hor != 0)
            {
                currentDirection = new Vector3(hor, vert, 0);

                playerTransform.position += maxSpeed * (currentDirection) * Time.deltaTime;
            }
        }

        playerTransform.eulerAngles = new Vector3(0, 0, Vector3.SignedAngle(currentDirection, new Vector3(0, 1, 0), -Vector3.forward));

    }
}

