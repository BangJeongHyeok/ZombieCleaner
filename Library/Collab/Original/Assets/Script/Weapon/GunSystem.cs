using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSystem : Weapon
{
    GameObject zombie;//테스트용

    // Start is called before the first frame update
    void Start()
    {
        //zombie = GameObject.Find("Zombie").transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        itemcode = Item.ItemCode.GunCleaner;
        Gun = GameObject.Find("Player").transform.GetChild(0).transform.GetChild(0).gameObject;
        A = false;
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);//마우스를 중심으로 레이캐스트
        Shoot();
        
        if(isClicked)
        {
            Timer();
            StartCoroutine(GunShoot());
        }
       
        
    }

    void Shoot()//마우스를 눌렀을때
    {
        if (Input.GetMouseButtonDown(0))
        {
            isClicked = true;
            Gun.transform.GetChild(0).GetComponent<Animator>().enabled = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isClicked = false;
            Gun.transform.localPosition = new Vector3(0f, 0f, 0f);
            Gun.transform.GetChild(0).GetComponent<Animator>().enabled = false;
        }
    }

    void Timer()//총이 데미지를 줄때 딜레이를 주기 위함
    {
        if (delayTime <= 0.1f)//여기 조건을 수정하면 딜레이를 수정할 수 있다.
        {
            delayTime += Time.deltaTime;
        }
        else
        {
            if (Physics.Raycast(ray, out rayHit))
                if (rayHit.transform.tag == "Enemy")
                {
                    rayHit.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Slider>().value -= 0.1f;//좀비 체력 줄이기
                    Debug.Log(rayHit.transform.tag);//태그를 기반으로 한 적 잡기
                }

            delayTime = 0;
        }
    }

    IEnumerator GunShoot()//총을 쏘는 애니메이션(총소기용)
    {
        if (A)
        {
            Gun.transform.localPosition = (Vector3)Random.insideUnitCircle * ShakingSize + Gun.transform.localPosition;
            A = false;
        }
        else
        {
            Gun.transform.localPosition = new Vector3(0f, 0f, 0f);
            A = true;
        }
        yield return null;
    }
}
