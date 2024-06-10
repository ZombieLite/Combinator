using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class ScoreStatic : MonoBehaviour
{
    [SerializeField] SpriteAtlas atlas;
    private int _score = 0;
    private GameObject[] _sprite = new GameObject[7];

    public void SetScore(int score)
    {
        string strScore;
        int scaleNum = 0;
        int strLength;

        _score = score;
        strScore = score.ToString();
        strLength = strScore.Length;

        if (strLength > 6)
        {
            strLength = 6;
            strScore = "999999";
        }

        for (int i = 0; i < strLength; i++)
        {
            if (_sprite[i] == null)
            {
                _sprite[i] = new GameObject("Score", typeof(RectTransform), typeof(Image));
                _sprite[i].transform.SetParent(gameObject.transform, false);
                _sprite[i].GetComponent<RectTransform>().sizeDelta = transform.GetComponent<RectTransform>().sizeDelta;
            }

            scaleNum += 25;
            _sprite[i].transform.localPosition = new Vector2(transform.position.x + scaleNum, transform.position.y);
            _sprite[i].GetComponent<Image>().sprite = atlas.GetSprite(strScore[i].ToString());
        }
    }

    public int GetScore()
    {
        return _score; 
    }
}
