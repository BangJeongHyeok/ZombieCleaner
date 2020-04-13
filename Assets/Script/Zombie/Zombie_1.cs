using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Zombie_1 : Zombie
{
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
        anime = GetComponentInChildren<Animator>();
        coll = GetComponent<SphereCollider>();

        nav.enabled = false;

        rigid.isKinematic = true;
        Hp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0)
        {   
            anime.SetBool("IsDead", true);
            nav.enabled = false;
            rigid.isKinematic = false;
            coll.isTrigger = false;
            IsDead = true;
        }
        else
        {
            if (Vector2.Distance(this.transform.position, Player.transform.position) < 20f)
            {
                coll.isTrigger = true;
                rigid.isKinematic = false;
                nav.enabled = true;
                nav.SetDestination(Player.transform.position);
            }
            else
            {
                rigid.isKinematic = false;
                nav.enabled = true;

                if (state == "Idle")
                {
                    Vector3 randomPos = Random.insideUnitSphere * 5f;
                    NavMeshHit navHit;
                    NavMesh.SamplePosition(transform.position + randomPos, out navHit, 20f, NavMesh.AllAreas);
                    nav.SetDestination(navHit.position);

                    state = "Walk";
                }

                if (state == "Walk")
                {
                    if (nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending)
                    {
                        state = "Idle";
                    }
                }
            }
        }
    }
}
