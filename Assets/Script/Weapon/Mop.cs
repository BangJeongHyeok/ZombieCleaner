using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mop : Weapon
{
    GameObject Sound;
    void Awake()
    {
        itemcode = Item.ItemCode.Mop;
        Gun = transform.parent.gameObject;
        IsDelay = false;
        isClicked = false;
        anime = gameObject.GetComponent<Animator>();
    }
    void Start()
    {
        Sound = GameObject.Find("SFXPlayer2");
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);//마우스를 중심으로 레이캐스트

        if (isClicked)
            Timer();

        if (!isClicked)
            Shoot();


        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f)//애니가 다끝날때
        {
            if (!isClicked)
            {
                gameObject.GetComponent<Animator>().Rebind();
                gameObject.GetComponent<Animator>().enabled = false;
                IsDelay = false;
            }

        }

        Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);

    }

    void Shoot()//마우스를 눌렀을때
    {
        if (!isClicked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isClicked = true;
                IsDelay = true;
                gameObject.GetComponent<Animator>().enabled = true;
                Sound.GetComponent<SFXManager2>().SoundManager_F("katana_Taking");
            }
        }
    }

    void Timer()//총이 데미지를 줄때 딜레이를 주기 위함
    {
        if (delayTime <= 0.8f)//여기 조건을 수정하면 딜레이를 수정할 수 있다.
        {
            delayTime += Time.deltaTime;
        }
        else
        {
            isClicked = false;
            delayTime = 0;
        }
    }

    public void isColl(Collider Wow)
    {
        if (IsDelay)
        {
            Wow.GetComponent<Zombie>().rigid.AddForce(transform.forward, ForceMode.Impulse);
            Wow.transform.GetComponent<Zombie>().Hp -= 0.04f;//좀비 체력 줄이기
        }
    }
}
