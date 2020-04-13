using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunCleaner : Weapon
{
    GameObject Sound;
    GameObject pointLight;
    public GameObject bullet;
    public GameObject Wind;
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        Sound = GameObject.Find("SFXPlayer2");
        pointLight = gameObject.transform.GetChild(1).gameObject;
        itemcode = Item.ItemCode.GunCleaner;
        Gun = transform.parent.gameObject;
        A = false;
        IsDelay = false;
        Wind.SetActive(false);
        isClicked = false;
        //Wind = transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);//마우스를 중심으로 레이캐스트
        Shoot();
        
        if(isClicked)
        {
            Wind.transform.Rotate(new Vector3(0, 0, 30f));
            if(Wind.transform.rotation.z >= 360)
            {
                Wind.transform.Rotate(new Vector3(0, 0, 360f));
            }
            Timer();
            StartCoroutine(GunShoot());
        }
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);


        if (isClicked)
        {
            if(Sound.GetComponent<AudioSource>().isPlaying == false)
            Sound.GetComponent<SFXManager2>().SoundManager_F("GunCleaner2");
            pointLight.SetActive(true);
            Wind.SetActive(true);
        }
        if (!isClicked)
        {
            pointLight.SetActive(false);
            Wind.SetActive(false);
        }
    }

    void Shoot()//마우스를 눌렀을때
    {
        if (Input.GetMouseButtonDown(0))
        {
            isClicked = true;
            gameObject.GetComponent<Animator>().enabled = true;
            Sound.GetComponent<SFXManager2>().SoundManager_F("GunCleaner");
        }
        if (Input.GetMouseButtonUp(0))
        {
            isClicked = false;
            Gun.transform.localPosition = new Vector3(0f, 0f, 0f);
            gameObject.GetComponent<Animator>().enabled = false;
            IsDelay = false;
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (Panel.GetComponent<Inventory>().BulletCount > 0)
            {
                Sound.GetComponent<SFXManager2>().SoundManager_F("katana_Taking");
                bullet.transform.position = new Vector3(
              CameraManager.instance.MainCamera.transform.position.x,
              CameraManager.instance.MainCamera.transform.position.y,
              CameraManager.instance.MainCamera.transform.position.z);
              

              GameObject.Instantiate(bullet, bullet.transform.position , CameraManager.instance.MainCamera.transform.rotation );
                Panel.GetComponent<Inventory>().BulletCount--;
            }
        }
    }

    void Timer()//총이 데미지를 줄때 딜레이를 주기 위함
    {
        if (delayTime <= 0.1f)//여기 조건을 수정하면 딜레이를 수정할 수 있다.
        {
            delayTime += Time.deltaTime;
            IsDelay = false;
        }
        else
        {
            IsDelay = true;
            delayTime = 0;
        }
    }



    public void isColl(Collider Wow)
    {
        if(IsDelay)
        {
            Wow.transform.GetComponent<Zombie>().Hp -= 0.3f;//좀비 체력 줄이기
        }

        if(isClicked && Wow.transform.GetComponent<Zombie>().Hp <= 0)
        { 
              
              Vector3 normal = transform.position - Wow.transform.position;

              normal.Normalize();

              Wow.transform.position += normal * 0.6f;
                  
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && other.GetComponent<Zombie>().Hp <= 0)
        {
            Destroy(other.gameObject);
            Panel.GetComponent<Inventory>().BulletCount++;
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
