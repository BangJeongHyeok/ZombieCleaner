using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammunition : MonoBehaviour
{
    public Text text;
    public GameObject amuuni;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        text.text = amuuni.GetComponent<Inventory>().BulletCount.ToString();
    }
}
