using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpGauge : MonoBehaviour
{
    private Image HpGaugeImage;
    private Zombie MyHp;

    void Start()
    {
        HpGaugeImage = gameObject.GetComponent<Image>();
        MyHp = gameObject.transform.parent.parent.parent.GetComponentInParent<Zombie>();
    }



    void Update()
    {
        HpGaugeImage.fillAmount = (float)((float)MyHp.Hp / (float)MyHp.MaxHp);
    }
}
