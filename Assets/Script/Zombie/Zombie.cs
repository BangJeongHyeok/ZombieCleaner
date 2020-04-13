using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{

    protected NavMeshAgent nav;
    protected string state = "Idle";
    protected GameObject Player;
    public Rigidbody rigid;
    protected Animator anime;
    protected SphereCollider coll;
    public bool IsDead = false;

    [HideInInspector] public float Hp;
    public float MaxHp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -15)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
