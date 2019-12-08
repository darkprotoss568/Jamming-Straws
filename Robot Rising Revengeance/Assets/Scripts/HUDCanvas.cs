using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDCanvas : MonoBehaviour
{
    public GameObject dialogBoxObjectPrefab;
    public GameObject actionPopupObjPrefab;
    public GameObject pauseScreen;
    private GameObject currentActionPopup;
    private GameObject currentDialogBox;

    private Camera cam;
    private RectTransform canvasRect;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        canvasRect = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateActionPopup(GameEvent e)
    {
        DestroyPopup();

        currentActionPopup = Instantiate(actionPopupObjPrefab, this.transform);
        CenterUIElementOnEvent(currentActionPopup, e, false);
        //Debug.Log("ePos" + e.transform.position);

        currentActionPopup.transform.Find("ActionText").GetComponent<Text>().text = e.command;
    }

    public void CreateDialogBox(UpgradeEvent e)
    {
        currentDialogBox = Instantiate(dialogBoxObjectPrefab, this.transform);
        CenterUIElementOnEvent(currentDialogBox, e, e.dialog[0].playerSide);

        FlipDialogBox(e.dialog[0].playerSide);

        currentDialogBox.transform.Find("DialogText").GetComponent<Text>().text = e.ProgressDialogue();

    }

    public void CenterUIElementOnEvent(GameObject obj, GameEvent e, bool onPlayer = false)
    {
        RectTransform r = obj.GetComponent<RectTransform>();
        Vector2 newPos;
        Vector3 targetPosition = e.transform.position;
        //Debug.Log("target: " + targetPosition);
        if (onPlayer)
        {
            targetPosition = GameManager.Instance.player.transform.position;
        }
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, cam.WorldToScreenPoint(targetPosition) + e.popupOffset, null, out newPos);
        newPos.x = Mathf.Clamp(newPos.x, -1980 / 2 + r.sizeDelta.x / 2, 1980 / 2 - r.sizeDelta.x / 2);
        newPos.y = Mathf.Clamp(newPos.y, -1080 / 2 + r.sizeDelta.y / 2, 1080 / 2 - r.sizeDelta.y / 2);

        r.localPosition = newPos;

    }

    public void AdvanceDialog()
    {
        UpgradeEvent currEvent = GameManager.Instance.currentLinkedGameEvent as UpgradeEvent;
        string newLine = currEvent.ProgressDialogue();
        if (newLine != null)
        {
            currentDialogBox.transform.Find("DialogText").GetComponent<Text>().text = newLine;
            CenterUIElementOnEvent(currentDialogBox, currEvent, currEvent.dialog[currEvent.CurrentLineIndex].playerSide);
            FlipDialogBox(currEvent.dialog[currEvent.CurrentLineIndex].playerSide);
        }
        else
        {
            Destroy(currentDialogBox);
            GameManager.Instance.player.SwitchPlayerState(PlayerState.Free);
        }
    }

    private void FlipDialogBox(bool playerSide)
    {
        Transform parent = currentDialogBox.gameObject.transform;
        Transform[] children = parent.GetComponentsInChildren<Transform>();
        for (int i = 0; i < children.Length; i++)
        {
            Vector3 newScale = children[i].localScale;
            if (playerSide)
            {
                newScale.x = 1;
            }
            else
            {
                newScale.x = -1;
            }

            children[i].localScale = newScale;
        }
    }

    public void ChangeCurrentPopupText(string newText)
    {
        if (currentActionPopup != null)
        {
            currentActionPopup.transform.Find("ActionText").GetComponent<Text>().text = newText;
        }

    }
    public void DestroyPopup()
    {
        if (currentActionPopup != null)
        {
            Destroy(currentActionPopup);
        }
    }
}
