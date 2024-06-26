using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.U2D;

public class Slot : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject ObjScore;

    ScoreStatic _score;

    private bool _isPaused;
    private void Awake() => PauseOnEnable.EventPause.AddListener(pauseScript);
    private void pauseScript(bool _pause) => _isPaused = !_pause;
    private SoundManager _sound => gameObject.transform.parent.GetComponent<SoundManager>();

    public void Start()
    {
        _score = ObjScore.GetComponent<ScoreStatic>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (_isPaused)
            return;

        if (eventData.pointerDrag != null)
        {
            if (gameObject.transform.GetComponent<Image>().sprite != null)
            {
                if (gameObject.name != eventData.pointerDrag.gameObject.name)
                    return;

                if (gameObject.transform.parent.gameObject.name == eventData.pointerDrag.transform.parent.gameObject.name) 
                    return;

                ScaleItem(eventData.pointerDrag.gameObject);
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
                _sound.PlaySound(2, 0.5f, true, false);
                GameObject item = Instantiate(gameObject, gameObject.transform);
                item.AddComponent<ItemMoveDnD>();
                item.AddComponent<SoundManager>();
                item.AddComponent<AudioSource>();
                item.GetComponent<SoundManager>().randSound = _sound.randSound;

                item.GetComponent<RectTransform>().localPosition = Vector2.zero;
                item.GetComponent<Image>().sprite = child.GetComponent<Image>().sprite;
                item.GetComponent<Image>().color = new Color(255f, 255f, 255f, 1.0f);
                item.GetComponent<Canvas>().sortingOrder = 4;    
                item.GetComponent<Image>().preserveAspect = true;
                item.name = eventData.pointerDrag.gameObject.name;
                _score.SetScore(_score.GetScore() + 1);

                Destroy(eventData.pointerDrag.gameObject, 0.001f);
            }
        }
    }

    private void ScaleItem(GameObject obj)
    {
        string szNamePre = gameObject.name.Substring(0, 1);
        string szNamePost = gameObject.name.Substring(2);
        string szName;

        int iName = int.Parse(szNamePre);
        iName++;

        if (iName > 6)
        {
            return;
        }

        _score.SetScore(_score.GetScore() + iName);
        szName = iName.ToString() + "_" + szNamePost;

        string strNewText = iName.ToString() + "_0";

        string atlasPath = "img/item/" + szNamePost + "/" + szNamePost;

        SpriteAtlas atlas = Resources.Load<SpriteAtlas>(atlasPath);

        gameObject.GetComponent<Image>().sprite = atlas.GetSprite(strNewText);

        gameObject.transform.name = szName;
        Destroy(obj, 0.001f);
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
