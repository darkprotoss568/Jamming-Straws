using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDCanvas : MonoBehaviour
{
    public GameObject dialogBoxObjectPrefab;
    public GameObject actionPopupObjPrefab;

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
        RectTransform r = currentActionPopup.GetComponent<RectTransform>();
        Vector2 newPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect,cam.WorldToScreenPoint(e.transform.position) + e.popupOffset, null, out newPos);
        Debug.Log(r.localPosition);
        newPos.x = Mathf.Clamp(newPos.x, -1980/2 + r.sizeDelta.x / 2, 1980/2 - r.sizeDelta.x / 2);
        newPos.y = Mathf.Clamp(newPos.y, -1080/2 + r.sizeDelta.y / 2,  1080/2 - r.sizeDelta.y / 2);
        r.localPosition = newPos;
        currentActionPopup.transform.Find("ActionText").GetComponent<Text>().text = e.command;
    }

    public void CreateDialogBox(GameEvent e)
    {
    
    }


    public void DestroyPopup()
    {
        if (currentActionPopup != null)
        {
            Destroy(currentActionPopup);
        }
    }
}
