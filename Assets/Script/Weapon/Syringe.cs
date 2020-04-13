using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : Weapon
{
    GameObject Sound;
    // Start is called before the first frame update
    void Start()
    {
        Sound = GameObject.Find("SFXPlayer2");
        itemcode = Item.ItemCode.Syringe;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();

        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)//애니가 다끝날때
        {
            gameObject.GetComponent<Animator>().enabled = false;
            GameObject.Find("Player").GetComponent<Player>().Hp += 30;
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Animator>().enabled = true;
            Sound.GetComponent<SFXManager2>().SoundManager_F("Syringe");
        }
    }
}
