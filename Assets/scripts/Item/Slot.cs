using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (gameObject.transform.GetComponent<Image>().sprite != null)
            {
                if (gameObject.transform.GetComponent<Image>().sprite != eventData.pointerDrag.transform.GetComponent<Image>().sprite)
                    return;

                ScaleItem();
                return;
            }


            if (eventData.pointerDrag.transform.parent.gameObject.transform.parent.name == "matrix")
            {
                eventData.pointerDrag.transform.SetParent(gameObject.transform, false);
                eventData.pointerDrag.transform.localPosition = Vector2.zero;
                return;
            }

            GameObject child = null;

            child = imgChild(eventData.pointerDrag.gameObject);

            if (child != null)
            {
                GameObject item = Instantiate(gameObject, gameObject.transform);
                item.AddComponent<ItemMoveDnD>();
                item.GetComponent<RectTransform>().localPosition = Vector2.zero;
                item.GetComponent<Image>().sprite = child.GetComponent<Image>().sprite;
                item.GetComponent<Image>().color = new Color(255f, 255f, 255f, 1.0f);
                item.GetComponent<Canvas>().sortingOrder = 4;               
                item.name = "0";

                Destroy(eventData.pointerDrag.gameObject, 0.001f);
            }
        }
    }

    private void ScaleItem()
    {

    }

    private GameObject imgChild(GameObject obj)
    {
        GameObject childernObj = null;
        Image[] btnChilds = new Image[obj.GetComponentsInChildren<Image>().Length];
        btnChilds = obj.GetComponentsInChildren<Image>();
        foreach (Image child in btnChilds)
        {

            if (child.name == "img")
            {
                childernObj = child.gameObject;
            }

        }
        return childernObj;
    }
}
