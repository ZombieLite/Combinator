using UnityEngine;

public class ItemCore : MonoBehaviour
{
    private const float TIMER_MAX_TIME = 0.01f;         //����� �������
    private float timerCurrentTime = TIMER_MAX_TIME;    //���������� ����������
    public bool stopped = false;

    void Update()
    {
        if (stopped)
            return;

        if (this.transform.position.x >= 6)
           return;


        if (timerCurrentTime > 0)                       // ����� ���������� ����� �� ����, �� ���������� ������������ �������
        {
            timerCurrentTime -= Time.deltaTime;         //��������� ���������� ����������
        }
        else
        {
            timerCurrentTime = TIMER_MAX_TIME;          // ��������� ����� ������� ����� ����� ����� � ������� ������
            this.transform.Translate(0.01f, 0, 0);      // � ������ ������ ������� ������ �� ����������� x (xyz)
        }
    }
}
