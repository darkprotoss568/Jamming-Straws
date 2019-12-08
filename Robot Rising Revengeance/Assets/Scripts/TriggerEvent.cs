using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : GameEvent
{
    public GameEvent linkedEvent = null;
    public bool requiresHackUnlock = true;
    public AudioClip hackFailedSound;
    public AudioClip hackSucceedSound;
    public override void Activate()
    {
        if (linkedEvent != null)
        {
            if (requiresHackUnlock)
            {
                if (!GameManager.Instance.player.hackUnlocked)
                {
                    GameManager.Instance.HUDScript.ChangeCurrentPopupText("You need the hack module");
                    GameManager.Instance.PlaySoundEffect(hackFailedSound);
                    // Play sound
                    return;
                }
            }
            GameManager.Instance.PlaySoundEffect(hackSucceedSound);
            linkedEvent.Activate();
            GameManager.Instance.currentLinkedGameEvent = linkedEvent;
            GameManager.Instance.HUDScript.DestroyPopup();
            hasBeenActivated = true;
        }
    }
}
