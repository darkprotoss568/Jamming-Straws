using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenEvent : GameEvent
{
    // Start is called before the first frame update
    void Start()
    {
        hasBeenActivated = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Open");
    }

}
