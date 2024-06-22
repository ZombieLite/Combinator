using UnityEngine;

public class ItemCore : MonoBehaviour
{
    private const float TIMER_MAX_TIME = 0.01f;         //время таймера
    private float timerCurrentTime = TIMER_MAX_TIME;    //внутренняя переменная
    public bool stopped = false;

    void Update()
    {
        if (stopped)
            return;

        if (this.transform.position.x >= 6)
           return;


        if (timerCurrentTime > 0)                       // Когда переменная будет на нуле, то выполнится передвижение объекта
        {
            timerCurrentTime -= Time.deltaTime;         //уменьшаем внутреннюю переменную
        }
        else
        {
            timerCurrentTime = TIMER_MAX_TIME;          // Обновляем время таймера когда время вышло и двигаем объект
            this.transform.Translate(0.01f, 0, 0);      // В данном случае двигаем объект по координатам x (xyz)
        }
    }
}
