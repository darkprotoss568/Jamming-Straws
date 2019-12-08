using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameEvent : GameEvent
{
    public override void Activate()
    {
        if (GameManager.Instance.player.normalMovementUnlocked)
        {
            // EndGameSequence
            GameManager.Instance.HUDScript.DestroyPopup();
            GameManager.Instance.player.SwitchPlayerState(PlayerState.EndGame);
        }
        else
        {
            GameManager.Instance.HUDScript.ChangeCurrentPopupText("You can't get up the stairs");
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
