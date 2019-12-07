using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent: MonoBehaviour
{
    Dialog dialog;
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
            Debug.Log("Linked");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.currentLinkedGameEvent = null;
            Debug.Log("Unlinked");
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