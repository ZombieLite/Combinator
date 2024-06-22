using System;
using UnityEngine;
using UnityEngine.Events;

public class PauseOnEnable : MonoBehaviour
{
    public static UnityEvent<bool> EventPause = new UnityEvent<bool>();

    private void OnEnable()
    {
        Time.timeScale = 0;
        EventPause?.Invoke(Convert.ToBoolean((int)Time.timeScale));
    }

    private void Update()
    {
        Time.timeScale = 0;
        EventPause?.Invoke(Convert.ToBoolean((int)Time.timeScale));
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
        EventPause?.Invoke(Convert.ToBoolean((int)Time.timeScale));
    }
}
