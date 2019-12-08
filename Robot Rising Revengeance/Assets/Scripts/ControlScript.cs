﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{
    private PlayerState currentState = PlayerState.Free;
    public float rotateSpeed;

    private Transform playerTransform;
    [Header("Movement")]
    public float normalSpeed;
    private float currentSpeed;
    public float sprintSpeed;
    private Vector3 currentDirection;
    public float acceleration;
    public float deceleration;
    [Header("Weapon")]
    public Transform muzzleTransform;
    public GameObject projectilePrefab;
    [Header("Upgrades Unlock")]
    public bool tankMovableWhileRotating = false;
    public bool normalMovementUnlocked = false;
    public bool sprintUnlocked = false;
    public bool hackUnlocked = false;
    public bool hasWeapon = false;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = 0;
        playerTransform = gameObject.transform;
        currentDirection = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        HandlePauseButtonInput();
        switch (currentState)
        {
            case PlayerState.Free:
                HandleMovementControls();
                CheckInteractionInput();
                CheckWeaponFireInput();
                break;
            case PlayerState.DialogEvent:
                CheckDialogInput();
                break;
        }
    }

    private void CheckWeaponFireInput()
    {
        if (hasWeapon && Input.GetButtonDown("Shoot"))
        {
            ProjectileScript newProjectile = Instantiate(projectilePrefab, muzzleTransform.position, Quaternion.identity).GetComponent<ProjectileScript>();
            newProjectile.Initialize(currentDirection);
        }
    }

    private void HandlePauseButtonInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                GameManager.Instance.HUDScript.pauseScreen.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                GameManager.Instance.HUDScript.pauseScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    private void CheckDialogInput()
    {
        if (Input.GetButtonDown("Interact"))
        {
            GameManager.Instance.HUDScript.AdvanceDialog();
        }
    }

    private void CheckInteractionInput()
    {
        if (Input.GetButtonDown("Interact"))
        {
            GameManager.Instance.ActivateEvent();
        }
    }

    private void HandleMovementControls()
    {
        float vert = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");

        float maxSpeed = normalSpeed;
        if (Input.GetButton("Sprint") && sprintUnlocked)
        {
            maxSpeed = sprintSpeed;
        }

        if (!normalMovementUnlocked)
        {
            if (hor > 0)
            {
                currentDirection = Quaternion.Euler(0, +rotateSpeed * Time.deltaTime, 0) * currentDirection;
            }
            else if (hor < 0)
            {
                currentDirection = Quaternion.Euler(0, -rotateSpeed * Time.deltaTime, 0) * currentDirection ;
            }


            if (hor == 0 || tankMovableWhileRotating)
            {

                if (vert > 0)
                {
                    currentSpeed = Mathf.Clamp(currentSpeed + acceleration*Time.deltaTime, 0, maxSpeed);
                    playerTransform.position += currentSpeed * (currentDirection) * Time.deltaTime;
                }
                else if (vert < 0)
                {
                    currentSpeed = Mathf.Clamp(currentSpeed + acceleration * Time.deltaTime, 0, maxSpeed);
                    playerTransform.position -= currentSpeed * (currentDirection) * Time.deltaTime;
                }
                else
                {
                    currentSpeed = Mathf.Clamp(currentSpeed - deceleration * Time.deltaTime, 0, maxSpeed);
                }
            }

        }
        else
        {
            if (vert != 0 || hor != 0)
            {
                currentSpeed = Mathf.Clamp(currentSpeed + acceleration * Time.deltaTime, 0, maxSpeed);
                currentDirection = new Vector3(hor, 0, vert);

                playerTransform.position += currentSpeed * (currentDirection) * Time.deltaTime;
            }
            else
                currentSpeed = Mathf.Clamp(currentSpeed - deceleration * Time.deltaTime, 0, maxSpeed);
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
