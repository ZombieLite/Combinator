using UnityEngine;

public class ItemTouch : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.name == "collider")
        {
            GetComponent<ItemCore>().stopped = true;
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.name == "collider")
        {
            GetComponent<ItemCore>().stopped = false;
        }
    }
}
