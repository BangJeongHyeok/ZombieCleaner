using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieKing : Zombie
{

    private float Delay;
    private float NowTime;
    private bool PatternExit = true;
    private bool isPattern;
    private Vector3 Target;
    private Vector3 Dir;


    public GameObject EndText;

    private bool Up_Down;

    public GameObject Zombie1;
    public GameObject Zombie2;
    public GameObject Zombie3;
    enum State
    {
        Idle,
        Follow,
        Pattern1,
        Spawn,
        Dead
    }

    State MyState;

    // Start is called before the first frame update
    void Start()
    {
        //transform.GetChild(1).gameObject.SetActive(false);
        Player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
        anime = GetComponentInChildren<Animator>();
        coll = GetComponent<SphereCollider>();

        nav.enabled = false;

        rigid.isKinematic = true;
        Hp = MaxHp;
        Delay = Random.Range(5, 8);
        NowTime = 0;

        MyState = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {

        if (isPattern)
        {
            nav.enabled = false;
            rigid.isKinematic = false;
            coll.isTrigger = false;
            IsDead = true;
        }
        else
        {
            nav.enabled = true;
            rigid.isKinematic = true;
            coll.isTrigger = true;
        }

        switch (MyState)
        {
            case State.Idle:
                rigid.isKinematic = false;

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
                break;
            case State.Follow:
                nav.SetDestination(Player.transform.position);
                anime.SetBool("IsAttack", false);
                anime.SetBool("IsSpawn", false);
                break;
            case State.Pattern1:
                anime.SetBool("IsAttack", true);
                Dir = Player.transform.position - transform.position;
                Dir.Normalize();
                if (Up_Down)
                {
                    if (transform.position.y > -1)
                        Up_Down = false;
                    else
                    {
                        rigid.AddForce((Dir * 0.7f + Vector3.up) * 0.5f, ForceMode.Impulse);
                        //rigid.velocity = Dir * 10f;
                    }
                }
                else
                {
                    if (rigid.transform.position.y <= -4 || anime.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f)
                    {
                        isPattern = false;
                        MyState = State.Follow;
                        rigid.velocity = Vector3.zero;
                    }
                    else
                        rigid.AddForce(Vector3.down, ForceMode.Impulse);
                }
                break;
            case State.Spawn:
                anime.SetBool("IsSpawn", true);

                if(anime.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f)
                {
                    Instantiate(Zombie1, new Vector3(transform.position.x + 2.5f, transform.position.y , transform.position.z) , this.transform.rotation);
                    Instantiate(Zombie1, new Vector3(transform.position.x - 2.5f, transform.position.y, transform.position.z), this.transform.rotation);
                    Instantiate(Zombie2, new Vector3(transform.position.x, transform.position.y , transform.position.z + 2.5f) , this.transform.rotation);
                    Instantiate(Zombie3, new Vector3(transform.position.x, transform.position.y, transform.position.z - 2.5f) , this.transform.rotation);
                    isPattern = false;
                    MyState = State.Follow;
                }
                break;
            case State.Dead:
                anime.SetBool("IsDead", true);
                nav.enabled = false;
                rigid.isKinematic = false;
                coll.isTrigger = false;
                EndText.SetActive(true);
                break;
        }

        if (Hp <= 0)
        {
            MyState = State.Dead;
        }
        else
        {
            if (Vector3.Distance(this.transform.position, Player.transform.position) < 50f)
            {
                if (rigid.velocity.y == 0 && !isPattern && MyState != State.Spawn)
                {
                    MyState = State.Follow;
                    isPattern = false;
                }

                if (Delay < NowTime)
                {
                    int RandNum = Random.Range(0, 3);

                    if (RandNum != 0)
                    {
                        MyState = State.Pattern1;
                        NowTime = 0;
                        Delay = Random.Range(5, 8);
                        isPattern = true;
                        Up_Down = true;
                    }
                    else
                    {
                        MyState = State.Spawn;
                        NowTime = 0;
                        Delay = Random.Range(5, 8);
                        isPattern = true;
                    }
                }
                else
                {
                    NowTime += Time.deltaTime; 
                }
            }
            else
            {
                MyState = State.Idle;
            }
        }
    }

    //void Smash()
    //{
    //    rigid.AddForce(Vector3.up, 3.f , ForceMode.Impulse);
    //    isPattern = false;
    //}

    private void LeftSmash()
    {

        PatternExit = true;
    }

    private void RightSmash()
    {
        PatternExit = true;
    }
}
