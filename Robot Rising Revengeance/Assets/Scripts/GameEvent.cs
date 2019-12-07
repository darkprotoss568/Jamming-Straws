﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEvent: MonoBehaviour
{
    public string command = "Talk";
    public Vector3 popupOffset;
    public bool hasBeenActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void Activate();

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !hasBeenActivated)
        {
            GameManager.Instance.currentLinkedGameEvent = this;
            GameManager.Instance.HUDScript.CreateActionPopup(this);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && !hasBeenActivated)
        {
            if (GameManager.Instance.currentLinkedGameEvent == this)
            {
                GameManager.Instance.currentLinkedGameEvent = null;
                GameManager.Instance.HUDScript.DestroyPopup();
            }
        }
    }

    public void DisableEvent()
    {
        gameObject.GetComponent<Collider>().isTrigger = false;
    }
}

[System.Serializable]
public class Dialog
{
    bool PlayerSide = true;
    public string speakerName;
    public string text;
}