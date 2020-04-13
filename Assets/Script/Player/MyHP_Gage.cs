using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyHP_Gage : MonoBehaviour
{
    public GameObject GameOver;
    private Image HpGaugeImage;
    private Player MyHp;
    void Start()
    {
        HpGaugeImage = GetComponent<Image>();
        MyHp = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        HpGaugeImage.fillAmount = (float)((float)MyHp.Hp / (float)MyHp.MaxHp);

        if (MyHp.Hp <= 0)
            GameOver.SetActive(true);
    }
}
