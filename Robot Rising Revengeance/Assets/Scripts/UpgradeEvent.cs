using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeEvent : GameEvent
{
    public bool hasDialog = false;
    public Dialog[] dialog;
    public UpgradeType upgradeType;
    private int currentLineIndex = -1;
    public int lineIndexToGiveUpgrade = 0;

    public int CurrentLineIndex { get => currentLineIndex;  }

    public override void Activate()
    {
        if (!hasBeenActivated)
        {
            if (dialog.Length > 0)
            {
                GameManager.Instance.player.SwitchPlayerState(PlayerState.DialogEvent);
                GameManager.Instance.HUDScript.CreateDialogBox(this);
            }
            else
            {
                GivePlayerUpgrade();
            }
            GameManager.Instance.HUDScript.DestroyPopup();

            hasBeenActivated = true;
        }
    }

    public void GivePlayerUpgrade()
    {
        ControlScript player = GameManager.Instance.player;
        switch (upgradeType)
        {
            case UpgradeType.ImprovedTankControl:
                player.tankMovableWhileRotating = true;
                player.wheelsPart.SetActive(true);
                player.trackPart.SetActive(false);
                break;
            case UpgradeType.Hack:
                player.hackUnlocked = true;
                player.hackingPart.SetActive(true);
                break;
            case UpgradeType.Speed:
                player.sprintUnlocked = true;
                player.enginePart.SetActive(true);
                break;
            case UpgradeType.Weapon:
                player.hasWeapon = true;
                player.launcherPart.SetActive(true);
                break;
            case UpgradeType.Leg:
                player.normalMovementUnlocked = true;
                player.hoverPart.SetActive(true);
                player.wheelsPart.SetActive(false);
                break;
        }
    }

    public string ProgressDialogue()
    {
        currentLineIndex++;
        if (currentLineIndex == lineIndexToGiveUpgrade)
        {
            GivePlayerUpgrade();
        }

        if (currentLineIndex >= dialog.Length)
        {
            return null;
        }
        else
        {
            Dialog currentLine = dialog[currentLineIndex];
            if (currentLine.soundClip != null)
            {
                GameManager.Instance.PlaySoundEffect(currentLine.soundClip);
            }
            string text = "";
            if (currentLine.speakerName != "")
            {
                text += currentLine.speakerName + ": ";
            }
            return text + currentLine.text;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}

public enum UpgradeType
{
    None,
    ImprovedTankControl,
    Hack,
    Speed,
    Weapon,
    Leg,
}