using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemMoveDnD : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    GameObject item;
    Image img;

    private bool _isPaused;
    private SoundManager _sound => GetComponent<SoundManager>();

    private void Awake()
    {
        PauseOnEnable.EventPause.AddListener(pauseScript);
        img = GetComponent<Image>();
    }

    private void pauseScript(bool _pause) => _isPaused = !_pause;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_isPaused)
            return;

        _sound.PlaySound(1, 0.5f, true, false);
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
        if (_isPaused)
            return;

        // Cursor position
        // ѕолучаем позицию курсора мыши
        Vector3 mousePosition = Input.mousePosition;

        // ѕреобразуем позицию курсора из экранных координат в мировые координаты
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        item.transform.position = new Vector3(worldMousePosition.x, worldMousePosition.y, transform.position.z);
        //item.GetComponent<RectTransform>().anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_isPaused)
            return;

        _sound.PlaySound(0, 0.5f, true, true);
        item.GetComponent<Image>().raycastTarget = true;
        img.color = new Color(255f, 255f, 1.0f);
        Destroy(item, 0.001f);
    }
}
