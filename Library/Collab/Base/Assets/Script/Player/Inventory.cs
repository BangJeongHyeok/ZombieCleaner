using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public enum ItemCode
    {
        Axe,
        Gun
    }
    private GameObject Slot1;
    private GameObject Slot2;
    private GameObject Slot3;
    private GameObject Slot4;

    private GameObject GettedItem;

    List<GameObject> itemlist;

    Transform gametrans;




    // Start is called before the first frame update
    void Start()
    {
        gametrans = transform.GetChild(0).GetComponent<Transform>();

        itemlist = new List<GameObject>();
        itemlist.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            gametrans.localPosition = new Vector3(80 - 300, 0, 0);
            if (itemlist.Count <= 0)
                return;
            if (itemlist[0])
                GetComponent<Player>().GetItem(itemlist[0]);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            gametrans.localPosition = new Vector3(226 - 300, 0, 0);
            if (itemlist.Count <= 0)
                return;
            if (itemlist[1])
                GetComponent<Player>().GetItem(itemlist[1]);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            gametrans.localPosition = new Vector3(372 - 300, 0, 0);
            if (itemlist.Count <= 0)
                return;
            if (itemlist[2])
                GetComponent<Player>().GetItem(itemlist[2]);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            gametrans.localPosition = new Vector3(520 - 300, 0, 0);
            if (itemlist.Count <= 0)
                return;
            if (itemlist[3])
                GetComponent<Player>().GetItem(itemlist[3]);
        }
        float Scroll = Input.GetAxis("Mouse ScrollWheel");

        Debug.Log(Scroll);
    }

    public GameObject GetItem(GameObject _item)
    {
        return _item;
    }

    public void AddItemList(GameObject _item)
    {

        if (itemlist.Count >= 4)
            return;

        itemlist.Add(_item);


    }

    
}
