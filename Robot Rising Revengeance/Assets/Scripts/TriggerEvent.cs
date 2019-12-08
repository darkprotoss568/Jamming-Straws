using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : GameEvent
{
    public GameEvent linkedEvent = null;
    public bool requiresHackUnlock = true;
    public override void Activate()
    {
        if (linkedEvent != null)
        {
            if (requiresHackUnlock)
            {
                if (!GameManager.Instance.player.hackUnlocked)
                {
                    return;
                }
            }
            linkedEvent.Activate();
            GameManager.Instance.currentLinkedGameEvent = linkedEvent;
            GameManager.Instance.HUDScript.DestroyPopup();
            hasBeenActivated = true;
        }
    }
}
