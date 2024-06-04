using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Runtime.CompilerServices;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Image image;
    private GameObject draggedImage;
    private Canvas canvas;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvas = GetComponentInParent<Canvas>();
        draggedImage = Instantiate(this.gameObject, rectTransform);
        draggedImage.transform.SetParent(canvas.transform, false);
        draggedImage.transform.localScale = rectTransform.parent.localScale;

        //Удаляем ненужные компоненты и объекты
        GameObject bcc = getChild(draggedImage);
        BoxCollider2D bc = draggedImage.GetComponent<BoxCollider2D>();
        Rigidbody2D rb = draggedImage.GetComponentInParent<Rigidbody2D>();
        itemManager im = draggedImage.GetComponent<itemManager>();
        Destroy(rb);
        Destroy(bc);
        Destroy(bcc);
        Destroy(im);

        // Cursor position
        // Получаем позицию курсора мыши
        Vector3 mousePosition = Input.mousePosition;

        // Преобразуем позицию курсора из экранных координат в мировые координаты
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        draggedImage.transform.position = new Vector3(worldMousePosition.x, worldMousePosition.y, draggedImage.transform.position.z);


        //Canvas Sorted
        draggedImage.AddComponent<Canvas>();
        draggedImage.GetComponent<Canvas>().overrideSorting = true;
        draggedImage.GetComponent<Canvas>().sortingOrder = 6;

        //Scale
        Vector3 v = new Vector3();
        v = draggedImage.GetComponent<RectTransform>().localScale;
        v.x /= 1.5f;
        v.y /= 2.5f;
        draggedImage.GetComponent<RectTransform>().localScale = v;

        draggedImage.GetComponent<BoxCollider2D>().enabled = false;
        draggedImage.GetComponent<ItemCore>().enabled = false;

        //Effect
        draggedImage.GetComponent<Image>().color = new Color(165f, 0f, 234f, 0.7f);
        GetComponent<Image>().color = new Color(255f, 0f, 0f, 0.5f);



        draggedImage.GetComponent<Image>().raycastTarget = false;
        draggedImage.GetComponent<Image>().sprite = this.image.sprite;
    }

    public void OnDrag(PointerEventData eventData)
    {
        draggedImage.GetComponent<RectTransform>().anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draggedImage.GetComponent<Image>().raycastTarget = true;
        GetComponent<Image>().color = new Color(255f, 255f, 1.0f);
        Destroy(draggedImage);
    }

    private GameObject getChild(GameObject obj)
    {
        GameObject childernObj = null;
        BoxCollider2D[] btnChilds = new BoxCollider2D[obj.GetComponentsInChildren<BoxCollider2D>().Length];
        btnChilds = obj.GetComponentsInChildren<BoxCollider2D>();
        foreach (BoxCollider2D child in btnChilds)
        {

            if (child.name == "collider")
            {
                childernObj = child.gameObject;
            }

        }
        return childernObj;
    }
}