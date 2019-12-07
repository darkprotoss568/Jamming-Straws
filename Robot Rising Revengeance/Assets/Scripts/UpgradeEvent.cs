using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeEvent : GameEvent
{
    public bool hasDialog = false;
    public Dialog dialog;
    public UpgradeType updateType;

    public override void Activate()
    {
        if (hasDialog)
        {

        }
        else
        {
            GameManager.Instance.HUDScript.DestroyPopup();
        }
    }

    private void GivePlayerUpgrade()
    {

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

public enum UpgradeType
{
    ImprovedTankControl,
    Hack,
    Speed,
    Weapon,
    Leg,
}