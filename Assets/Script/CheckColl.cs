using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColl : MonoBehaviour
{
    private GunCleaner Gunsystem;
    private Mop Mopsystem;
    private Katana Katanasystem;
    public CapsuleCollider coll;
    // Start is called before the first frame update
    void Start()
    {
        Gunsystem = transform.GetChild(0).transform.GetChild(0).GetComponent<GunCleaner>();
        Mopsystem = transform.GetChild(0).transform.GetChild(1).GetComponent<Mop>();
        Katanasystem = transform.GetChild(0).transform.GetChild(2).GetComponent<Katana>();
        coll = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Gunsystem.isColl(other);
            Katanasystem.isColl(other);
            Mopsystem.isColl(other);
        }
    }
}
