using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemManager : MonoBehaviour
{
    [SerializeField] private int items;
    public List<Sprite> brick;
    public List<Sprite> wood;

    private Sprite spr;

    public void Start()
    {
        int randomIndex = Random.Range(0, items);

        switch (randomIndex)
        {
            case 0:
                spr = brick[0];
                break;
            case 1:
                spr = wood[0];
                break;
        }
        imgChild(gameObject, "img").GetComponent<Image>().sprite = spr;
    }

    private GameObject imgChild(GameObject obj, string name)
    {
        GameObject childernObj = null;
        Image[] btnChilds = new Image[obj.GetComponentsInChildren<Image>().Length];
        btnChilds = obj.GetComponentsInChildren<Image>();
        foreach (Image child in btnChilds)
        {

            if (child.name == name)
            {
                childernObj = child.gameObject;
            }

        }
        return childernObj;
    }
}