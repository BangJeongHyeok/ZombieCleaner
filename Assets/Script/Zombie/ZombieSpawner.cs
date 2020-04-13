using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject Zombie;
    float Delay;
    // Start is called before the first frame update
    void Start()
    {
        Delay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Delay > 10f)
        {
            Instantiate(Zombie, new Vector3(transform.position.x + 2.5f, transform.position.y, transform.position.z), this.transform.rotation);
            Delay = 0;
        }
        else
            Delay += Time.deltaTime;
    }
}
