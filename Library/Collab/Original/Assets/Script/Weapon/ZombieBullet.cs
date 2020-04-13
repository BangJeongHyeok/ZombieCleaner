using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBullet : Weapon
{
    
    Vector3 dir;
    public float bulletSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTarget(Vector3 startvec ,Vector3 target)
    {
        dir = (target - startvec);
        transform.position = startvec;
        GetComponent<Rigidbody>().velocity = (dir.normalized * bulletSpeed * Time.deltaTime);
    }
}
