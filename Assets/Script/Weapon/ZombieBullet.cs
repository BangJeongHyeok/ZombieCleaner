using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBullet : Weapon
{
    
    Vector3 dir;
    public float bulletSpeed;
    public Rigidbody rigid;
    bool Stop;

    // Start is called before the first frame update
    void Start()
    {
        Stop = false;
        //rigid.AddForce(transform.forward * 3f, ForceMode.Impulse);    
    }

    // Update is called once per frame
    void Update()
    {
        if(!Stop)
        transform.Translate(Vector3.forward * 1f);


        if (transform.position.y < -15)
        {
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Enemy")
        {
            other.transform.GetComponent<Zombie>().Hp -= 3f;
            //other.transform.GetComponent<Zombie_1>().Hp -= 10f;
            //other.transform.GetComponent<ZombieKing>().Hp -= 10f;
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "OMG")
        {
            Stop = true;
            rigid.isKinematic = true;
        }
    }


    //public void SetTarget(Vector3 startvec ,Vector3 target)
    //{
    //    dir = (target - startvec);
    //    transform.position = startvec;
    //    GetComponent<Rigidbody>().velocity = dir.normalized * bulletSpeed * Time.deltaTime;
    //}
}
