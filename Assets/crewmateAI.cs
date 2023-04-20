using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crewmateAI : MonoBehaviour
{
    private Animation anim;
    private Rigidbody rb;
    public GameObject target;
    public float walkingSpeed = 110f;
    public float attackDistance = 1.5f;
    public bool die = false;
    private float deathStart = 0;
    private float stumbleStart = 0;
    public int startingHealth = 3;
    public int health;
    private bool playingDeathAnim = false;
    public float animationSpeed = 1.0f;
    public LevelControl levelControler;

    void Start()
    {
        health = startingHealth;
        anim = gameObject.GetComponent<Animation>();
        rb = gameObject.GetComponent<Rigidbody>();
        foreach (AnimationState state in anim)
        {
            state.speed = 1.0F;
            state.wrapMode = WrapMode.Loop;
        }
        anim["death"].wrapMode = WrapMode.Once;
    }

    // Update is called once per frame
    void Update()
    {
        if (die)
        {
            rb.velocity = new Vector3(0, 0, 0);
            if (!playingDeathAnim)
            {
                Debug.Log("playing");
                playingDeathAnim = true;
                anim.Play("death");
                deathStart = Time.time;
            }
            if (Time.time - deathStart > 0.95f)
            {
                Debug.Log("dead");
                levelControler.numAliveEnemys -= 1;
                gameObject.SetActive(false);
            }

        }
        else
        {
            if (Time.time - stumbleStart < 1) // When the stumble start time is set the enemy will pause for x seconds
            {
                anim.CrossFade("stumble", .2f);
                rb.velocity = new Vector3(0, 0, 0);
                LookAtTarget();
            }
            else if (Vector3.Distance(gameObject.transform.position, target.transform.position) < attackDistance)
            {
                anim.CrossFade("attack", 1.5f);
                rb.velocity = new Vector3(0, 0, 0);
                LookAtTarget();
            }
            else
            {
                anim.CrossFade("walk", 1.5f);
                Vector3 enemyToTarget = target.transform.position - gameObject.transform.position;
                Vector3 movementVector = enemyToTarget.normalized * walkingSpeed * Time.deltaTime;
                movementVector.y = 0;
                rb.velocity = movementVector;
                LookAtTarget();
            }
        }
    }

    private void LookAtTarget()
    {
        Vector3 lookAtYZeroed = target.transform.position;
        lookAtYZeroed.y = gameObject.transform.position.y;
        gameObject.transform.LookAt(lookAtYZeroed, Vector3.up);
    }

    private float vector2DDistance(Vector3 v1, Vector3 v2)
    {
        float xDiff = v1.x - v2.x;
        float zDiff = v1.z - v2.z;
        return Mathf.Sqrt((xDiff * xDiff) + (zDiff * zDiff));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log(health);
            health -= other.gameObject.GetComponent<BulletDamage>().damage;
            if (health > 0)
            {
                stumbleStart = Time.time;
            }
            else
            {
                die = true;
                deathStart = Time.time;
            }
        }
    }
}


