using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemMoveDnD : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    GameObject item;
    Image img;
    private void Awake()
    {
        img = GetComponent<Image>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        item = Instantiate(gameObject, gameObject.transform);
        // Cursor position
        // ѕолучаем позицию курсора мыши
        Vector3 mousePosition = Input.mousePosition;

        // ѕреобразуем позицию курсора из экранных координат в мировые координаты
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        item.transform.position = new Vector3(worldMousePosition.x, worldMousePosition.y, transform.position.z);
        item.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.7f);
        GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.5f);
        item.GetComponent<Image>().raycastTarget = false;
        item.GetComponent<Image>().preserveAspect = true;
        item.name = gameObject.transform.parent.gameObject.name;
    }

    public void OnDrag(PointerEventData eventData)
    {
        item.GetComponent<RectTransform>().anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        item.GetComponent<Image>().raycastTarget = true;
        img.color = new Color(255f, 255f, 1.0f);
        Destroy(item, 0.001f);
    }
}
