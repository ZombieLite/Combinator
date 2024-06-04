using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject pref;
    private bool stopped = false;
    void Start()
    {
        InvokeRepeating(nameof(SpawnItem), 3f, 3f);
    }

    void SpawnItem()
    {
        if (stopped)
            return;

        GameObject item = Instantiate(pref, this.transform);
        item.transform.SetParent(this.transform);
        item.transform.position = this.transform.position;
        item.transform.position = new Vector3(-7.0f, item.transform.position.y, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "collider")
        {
            stopped = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "collider")
        {
            stopped = false;
        }
    }
}
