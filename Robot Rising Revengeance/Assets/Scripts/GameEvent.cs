using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent: MonoBehaviour
{
    public string command = "Talk";
    public Vector3 popupOffset;
    public Dialog dialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.currentLinkedGameEvent = this;
            GameManager.Instance.HUDScript.CreateActionPopup(this);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
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
    public string speakerName;
    public string text;
}