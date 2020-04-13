using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Katana : Weapon
{
    GameObject Sound;
    GameObject PlayerObject;
    private CharacterController Player_Controller;
    Vector3 PlayerView;
    public bool isAnimation = false;
    public GameObject skillui;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerObject = GameObject.Find("Player");
        Player_Controller = gameObject.transform.parent.parent.parent.gameObject.GetComponent<CharacterController>();//Player의 리지드바디
        itemcode = Item.ItemCode.Katana;
        Gun = transform.parent.gameObject;
        A = false;
        IsDelay = false;
        isClicked = false;
        anime = gameObject.GetComponent<Animator>();

        Sound = GameObject.Find("SFXPlayer2");
        skillui.GetComponent<Image>().fillAmount = 0;
    }
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        PlayerView = transform.localPosition;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);//마우스를 중심으로 레이캐스트

        if (skillui.GetComponent<Image>().fillAmount > 0)
            Timer();

        if(skillui.GetComponent<Image>().fillAmount <= 0)
            Shoot();

        if (isAnimation)
            AnimationDoing();

        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)//애니가 다끝날때
        {
            isAnimation = false;
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
        if (Input.GetMouseButtonDown(0))
        {
            isAnimation = true;
            isClicked = true;
            IsDelay = true;
            gameObject.GetComponent<Animator>().enabled = true;
            Sound.GetComponent<SFXManager2>().SoundManager_F("katana_Taking");
        }
    }

    void AnimationDoing()
    {
        skillui.GetComponent<Image>().fillAmount = 1;
        PlayerObject.transform.Translate(0, 0, 1.2f);
    }



    void Timer()//총이 데미지를 줄때 딜레이를 주기 위함
    {
        if (delayTime <= 3f)//여기 조건을 수정하면 딜레이를 수정할 수 있다.
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
        if (isAnimation)
        {
            Wow.transform.GetComponent<Zombie_1>().Hp -= 5f;//좀비 체력 줄이기
        }
    }
}