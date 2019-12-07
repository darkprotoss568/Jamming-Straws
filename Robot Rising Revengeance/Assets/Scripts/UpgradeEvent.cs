using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeEvent : GameEvent
{
    public bool hasDialog = false;
    public Dialog[] dialog;
    public UpgradeType upgradeType;
    public int currentLineIndex = 0;
    public int lineIndexToGiveUpgrade = 0;


    public override void Activate()
    {
        if (!hasBeenActivated)
        {
            if (hasDialog)
            {
                GameManager.Instance.player.SwitchPlayerState(PlayerState.DialogEvent);
                GameManager.Instance.HUDScript.CreateDialogBox(this);
            }
            else
            {
                GameManager.Instance.HUDScript.DestroyPopup();
            }

            hasBeenActivated = false;
        }
    }

    public void GivePlayerUpgrade()
    {
        switch (upgradeType)
        {
            case UpgradeType.ImprovedTankControl:
                GameManager.Instance.player.tankMovableWhileRotating = true;
                break;
            case UpgradeType.Hack:
                GameManager.Instance.player.hackUnlocked = true;
                break;
            case UpgradeType.Speed:
                GameManager.Instance.player.sprintUnlocked = true;
                break;
            case UpgradeType.Weapon:
                GameManager.Instance.player.hasWeapon = true;
                break;
            case UpgradeType.Leg:
                GameManager.Instance.player.normalMovementUnlocked = true;
                break;
        }
    }

    public int ProgressDialogue()
    {
        currentLineIndex++;
        if (currentLineIndex == lineIndexToGiveUpgrade)
        {
            GivePlayerUpgrade();
        }

        return currentLineIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum UpgradeType
{
    ImprovedTankControl,
    Hack,
    Speed,
    Weapon,
    Leg,
}