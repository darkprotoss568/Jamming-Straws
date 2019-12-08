using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEvent: MonoBehaviour
{
    public string command = "Talk";
    public Vector3 popupOffset;
    protected bool hasBeenActivated = false;
    // Start is called before the first frame update

    public GameEvent eventLock;
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
            if (eventLock != null)
            {
                if (!eventLock.hasBeenActivated)
                {
                    return;
                }
            }
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
    public bool playerSide = true;
    public string speakerName;
    public string text;
    public AudioClip soundClip;

}