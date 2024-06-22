using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundChangeOnEnable : MonoBehaviour
{
    [SerializeField] private Sprite IconIsSound;
    [SerializeField] private Sprite IconNoSound;

    private Image _image => GetComponent<Image>();

    private bool _isSound = false;
    private void Awake() => AudioListener.volume = Convert.ToInt32(_isSound);

    public void ChangeSound()
    {
        _isSound = !_isSound;
        _image.sprite = _isSound ? IconIsSound : IconNoSound;
        AudioListener.volume = Convert.ToInt32(_isSound);
    }
}
