using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private SpriteRenderer Slot1;
    private SpriteRenderer Slot2;
    private SpriteRenderer Slot3;
    private SpriteRenderer Slot4;

    public GameObject guncleaner = null;
    public GameObject mop = null;
    public GameObject katana = null;
    public GameObject syringe = null;

    Sprite spr;
    public int SyringeCount = 0;
    public int BulletCount = 0;

    List<GameObject> itemlist;

    Transform gametrans;

    private int CurrentItem;
    // Start is called before the first frame update
    void Start()
    {
        spr = (Sprite)Resources.Load("Textures/empty", typeof(Sprite));
        Slot1 = transform.GetChild(1).GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        Slot2 = transform.GetChild(2).GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        Slot3 = transform.GetChild(3).GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        Slot4 = transform.GetChild(4).GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>();


        gametrans = transform.GetChild(0).GetComponent<Transform>();
        

        itemlist = new List<GameObject>();
        itemlist.Clear();

        guncleaner.SetActive(true);
        mop.SetActive(false);
        katana.SetActive(false);    
        syringe.SetActive(false);

        itemlist.Add(guncleaner);
        itemlist.Add(mop);
        itemlist.Add(katana);
        itemlist.Add(syringe);


        CurrentItem = 0;
    }

    // Update is called once per frame
    void Update()
    {
        katana.GetComponent<Katana>().skillui.GetComponent<Image>().fillAmount -= 1 * Time.smoothDeltaTime / 3f;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentItem = 0;
            guncleaner.GetComponent<GunCleaner>().isClicked = false;
            mop.GetComponent<Mop>().isClicked = false;
            guncleaner.GetComponent<GunCleaner>().IsDelay = false;
            mop.GetComponent<Mop>().IsDelay = false;
            katana.GetComponent<Katana>().isClicked = false;
            katana.GetComponent<Katana>().isAnimation = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentItem = 1;
            guncleaner.GetComponent<GunCleaner>().isClicked = false;
            mop.GetComponent<Mop>().isClicked = false;
            guncleaner.GetComponent<GunCleaner>().IsDelay = false;
            mop.GetComponent<Mop>().IsDelay = false;
            katana.GetComponent<Katana>().isClicked = false;
            katana.GetComponent<Katana>().isAnimation = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentItem = 2;
            guncleaner.GetComponent<GunCleaner>().isClicked = false;
            mop.GetComponent<Mop>().isClicked = false;
            guncleaner.GetComponent<GunCleaner>().IsDelay = false;
            mop.GetComponent<Mop>().IsDelay = false;
            katana.GetComponent<Katana>().isClicked = false;
            katana.GetComponent<Katana>().isAnimation = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CurrentItem = 3;
            guncleaner.GetComponent<GunCleaner>().isClicked = false;
            mop.GetComponent<Mop>().isClicked = false;
            guncleaner.GetComponent<GunCleaner>().IsDelay = false;
            mop.GetComponent<Mop>().IsDelay = false;
            katana.GetComponent<Katana>().isClicked = false;
            katana.GetComponent<Katana>().isAnimation = false;
        }


        switch (CurrentItem)
        {
            case 0:
                gametrans.localPosition = new Vector3(80 - 300, 0, 0);

                guncleaner.SetActive(true);
                mop.GetComponent<Mop>().isClicked = false;
                mop.GetComponent<Mop>().IsDelay = false;
                mop.SetActive(false);
                katana.GetComponent<Katana>().isClicked = false;
                katana.GetComponent<Katana>().isAnimation = false;
                katana.SetActive(false);
                syringe.GetComponent<Syringe>().isClicked = false;
                syringe.SetActive(false);

                break;
            
            case 1:
                gametrans.localPosition = new Vector3(226 - 300, 0, 0);

                guncleaner.GetComponent<GunCleaner>().isClicked = false;
                guncleaner.GetComponent<GunCleaner>().IsDelay = false;
                guncleaner.SetActive(false);
                mop.SetActive(true);
                katana.GetComponent<Katana>().isClicked = false;
                katana.GetComponent<Katana>().isAnimation = false;
                katana.SetActive(false);
                syringe.GetComponent<Syringe>().isClicked = false;
                syringe.SetActive(false);
                
                break;
            case 2:
                gametrans.localPosition = new Vector3(372 - 300, 0, 0);

                guncleaner.GetComponent<GunCleaner>().isClicked = false;
                guncleaner.SetActive(false);
                mop.GetComponent<Mop>().isClicked = false;
                mop.GetComponent<Mop>().IsDelay = false;
                mop.SetActive(false);
                katana.SetActive(true);
                syringe.GetComponent<Syringe>().isClicked = false;
                syringe.SetActive(false);
                
                break;
            case 3:
                gametrans.localPosition = new Vector3(520 - 300, 0, 0);

                guncleaner.GetComponent<GunCleaner>().isClicked = false;
                guncleaner.GetComponent<GunCleaner>().IsDelay = false;
                guncleaner.SetActive(false);
                mop.GetComponent<Mop>().isClicked = false;
                mop.GetComponent<Mop>().IsDelay = false;
                mop.SetActive(false);
                katana.GetComponent<Katana>().isClicked = false;
                katana.GetComponent<Katana>().isAnimation = false;
                katana.SetActive(false);
                syringe.SetActive(true);

                break;
        }
        float Scroll = Input.GetAxis("Mouse ScrollWheel");

        if (Scroll < 0)
        {
            if (CurrentItem == 3)
                CurrentItem = 0;
            else
                CurrentItem++;
            guncleaner.GetComponent<GunCleaner>().isClicked = false;
            mop.GetComponent<Mop>().isClicked = false;
            katana.GetComponent<Katana>().isClicked = false;
            katana.GetComponent<Katana>().isAnimation = false;
        }
        else if (Scroll > 0)
        {
            if (CurrentItem == 0)
                CurrentItem = 3;
            else
                CurrentItem--;
            guncleaner.GetComponent<GunCleaner>().isClicked = false;
            mop.GetComponent<Mop>().isClicked = false;
            katana.GetComponent<Katana>().isClicked = false;
            katana.GetComponent<Katana>().isAnimation = false;
        }
    }

    public GameObject GetItem(GameObject _item)
    {
        return _item;
    }

    public void AddItemList(GameObject _item)
    {
        if (itemlist.Count >= 4)
            return;
        
        
        switch(_item.GetComponent<Weapon>().GetItemCode())
        {
            case Item.ItemCode.GunCleaner:
                break;
            case Item.ItemCode.Mop:
                Slot2.gameObject.SetActive(true);
                break;
            case Item.ItemCode.Katana:
                Slot3.gameObject.SetActive(true);
                break;
            case Item.ItemCode.Syringe:
                Slot4.gameObject.SetActive(true);
                SyringeCount++;
                break;
        }

    }

    
}
