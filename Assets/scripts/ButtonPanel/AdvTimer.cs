using UnityEngine;
using UnityEngine.UI;
using YG;

public class AdvTimer : MonoBehaviour
{
    private Image image;
    private Text text;
    private string _text;
    [SerializeField] private float TIMER_MAX_TIME;         //время таймера
    [SerializeField] private GameObject objText;
    private float timerCurrentTime;
    private float percent;

    private void Awake()
    {
        image = GetComponent<Image>();
        text = objText.GetComponent<Text>();
        _text = text.text;
        text.text = "";
    } 
    private void Start() => timerCurrentTime = TIMER_MAX_TIME;

    private void Update()
    {
        if (timerCurrentTime > 0)
        {
            timerCurrentTime -= Time.deltaTime;
            percent = (1.000f - timerCurrentTime / TIMER_MAX_TIME);
            image.fillAmount = percent;

            if (timerCurrentTime < 5)
            {
                text.text = "" + _text + Mathf.Round(timerCurrentTime);
            }
        }
        else
        {
            timerCurrentTime = TIMER_MAX_TIME;          // Обновляем время таймера когда время вышло и двигаем объект
            text.text = "";
            YandexGame.FullscreenShow();
        }
    }
}
