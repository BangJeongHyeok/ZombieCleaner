using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected Item.ItemCode itemcode;
    protected Ray ray;
    protected RaycastHit rayHit;
    protected GameObject Gun;
    public bool isClicked = false;
    protected float ShakingSize = 0.016f;
    protected bool A;
    protected float delayTime = 0;
    protected GameObject zombie;
    public bool IsDelay;

    public Animator anime;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Item.ItemCode GetItemCode()
    {
        return itemcode;
    }
}
