using UnityEngine;
using UnityEngine.UI;

public class PauseChange : MonoBehaviour
{
    [SerializeField] private Sprite IconIsPause;
    [SerializeField] private Sprite IconNoPause;
    [SerializeField] private GameObject PauseText;

    private Image _image => GetComponent<Image>();
    private Image _imageText => PauseText.GetComponent<Image>();
    private PauseOnEnable _pauseScript => PauseText.GetComponent<PauseOnEnable>();

    private bool _isActive = false;

    public void ChangePause()
    {
        _isActive = !_isActive;
        _image.sprite = _isActive ? IconIsPause : IconNoPause;
        _imageText.enabled = _isActive;
        _pauseScript.enabled = _isActive;
    }
}
