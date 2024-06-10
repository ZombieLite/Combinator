using UnityEditor;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class itemManager : MonoBehaviour
{
    [SerializeField] private int items;
    [SerializeField] SpriteAtlas atlas_brick;
    [SerializeField] SpriteAtlas atlas_wood;
    [SerializeField] SpriteAtlas atlas_eats;
    [SerializeField] SpriteAtlas atlas_energy;
    [SerializeField] SpriteAtlas atlas_ingot;
    [SerializeField] SpriteAtlas atlas_instr;
    [SerializeField] SpriteAtlas atlas_plate;
    [SerializeField] SpriteAtlas atlas_ruda;
    [SerializeField] SpriteAtlas atlas_thread;
    [SerializeField] SpriteAtlas atlas_write;

    private Sprite spr;

    public void Start()
    {
        int randomIndex = Random.Range(0, items);
        string szName = "obj";

        switch (randomIndex)
        {
            case 0:
                spr = atlas_brick.GetSprite("1_0");
                szName = "1_brick";
                break;
            case 1:
                spr = atlas_wood.GetSprite("1_0");
                szName = "1_wood";
                break;
            case 2:
                spr = atlas_eats.GetSprite("1_0");
                szName = "1_eats";
                break;
            case 3:
                spr = atlas_energy.GetSprite("1_0");
                szName = "1_energy";
                break;
            case 4:
                spr = atlas_ingot.GetSprite("1_0");
                szName = "1_ingot";
                break;
            case 5:
                spr = atlas_instr.GetSprite("1_0");
                szName = "1_instr";
                break;
            case 6:
                spr = atlas_plate.GetSprite("1_0");
                szName = "1_plate";
                break;
            case 7:
                spr = atlas_ruda.GetSprite("1_0");
                szName = "1_ruda";
                break;
            case 8:
                spr = atlas_thread.GetSprite("1_0");
                szName = "1_thread";
                break;
            case 9:
                spr = atlas_write.GetSprite("1_0");
                szName = "1_write";
                break;
        }
        imgChild(gameObject, "img").GetComponent<Image>().sprite = spr;
        gameObject.name = szName;
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