using UnityEngine;

public class GameManagers : MonoBehaviour
{
    private SoundManager _sound => GetComponent<SoundManager>();
    void Start()
    {
        _sound.PlaySound(0, 0.3f, false);
    }
}
