using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{
    private PlayerState currentState = PlayerState.Free;
    public float rotateSpeed;

    private Transform playerTransform;

    public float normalSpeed;


    public float sprintSpeed;
    private Vector3 currentDirection;

    [Header("Upgrades Unlock")]
    public bool tankMovableWhileRotating = false;
    public bool normalMovementUnlocked = false;
    public bool sprintUnlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = gameObject.transform;
        currentDirection = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case PlayerState.Free:
                HandleMovementControls();
                CheckInteractionInput();
                break;
            case PlayerState.DialogEvent:
                break;
        }
    }

    private void CheckInteractionInput()
    {
        if (Input.GetButtonDown("Interact"))
        {

        }
    }

    private void HandleMovementControls()
    {
        float vert = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");

        float speed = normalSpeed;
        if (Input.GetButton("Sprint"))
        {
            speed = sprintSpeed;
        }

        if (!normalMovementUnlocked)
        {

            if (hor > 0)
            {
                currentDirection = Quaternion.Euler(0, +rotateSpeed, 0) * currentDirection;
            }
            else if (hor < 0)
            {
                currentDirection = Quaternion.Euler(0, -rotateSpeed, 0) * currentDirection;
            }
            if (hor == 0 || tankMovableWhileRotating)
            { 
                if (vert > 0)
                {
                    playerTransform.position += speed * (currentDirection) * Time.deltaTime;
                }
                else if (vert < 0)
                {
                    playerTransform.position -= speed * (currentDirection) * Time.deltaTime;
                }
            }

        }
        else
        {
            if (vert != 0 || hor != 0)
            {
                currentDirection = new Vector3(hor, 0, vert);

                playerTransform.position += speed * (currentDirection) * Time.deltaTime;
            }
        }

        playerTransform.eulerAngles = new Vector3(0, Vector3.SignedAngle(currentDirection, new Vector3(0, 0, 1), -Vector3.up), 0);

    }

    public void SwitchPlayerState(PlayerState newState)
    {
        currentState = newState;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ConveyerBelt")
        {

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "ConveyerBelt")
        {

        }
    }
}


public enum PlayerState
{
    Free,
    DialogEvent
}
