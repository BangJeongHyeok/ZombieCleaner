using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject Item;

    [HideInInspector] public float Hp;
    public float MaxHp;
    float Delay;
    bool Coll;
    // Start is called before the first frame update
    void Awake()
    {
    }
    void Start()
    {
        Hp = MaxHp;
    }
    // Update is called once per frame
    void Update()
    {
        //if (Coll)
        //{
        //    if (Delay > 1f)
        //    {
        //        Delay = 0;
        //        Coll = false;
        //    }
        //    else
        //        Delay += Time.deltaTime;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            GetComponent<Inventory>().AddItemList(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.tag);
        if(other.tag == "Enemy")
        {
            Hp -= 0.1f;
        }
        else if (other.CompareTag("Enemy"))
        {
            Hp -= 0.1f;
        }
    }
    public void GetItem(GameObject item)
    {
        Item = item;
    }
}
