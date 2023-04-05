using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    private Animation anim;
    private Rigidbody rb;
    public string animationName = "Walk";
    public GameObject target;
    public float walkingSpeed = 0.9f;
    public float runningSpeed = 1.5f;
    public float idleSpeed = 0;
    public float attackDistance = 1.5f;
    public bool die = false;
    private float deathStart = 0;

    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        rb = gameObject.GetComponent<Rigidbody>();
        foreach (AnimationState state in anim)
        {
            state.speed = 1.0F;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (die)
        {
            if (Time.time-deathStart>1.5f)
            {
                gameObject.SetActive(false);
            }
            anim.CrossFade("Death", 1.5f);
            rb.velocity = new Vector3(0, 0, 0);
        }
        else
        {
            if (Vector3.Distance(gameObject.transform.position, target.transform.position) < attackDistance)
            {
                anim.CrossFade("Attack1", 1.5f);
                rb.velocity = new Vector3(0,0,0);
                Vector3 lookAtYZeroed = target.transform.position;
                lookAtYZeroed.y = gameObject.transform.position.y;
                gameObject.transform.LookAt(lookAtYZeroed, Vector3.up);
            }
            else
            {
                anim.CrossFade("Walk", 1.5f);
                Vector3 enemyToTarget = target.transform.position - gameObject.transform.position;
                Vector3 movementVector = enemyToTarget.normalized * walkingSpeed * Time.deltaTime;
                movementVector.y = 0;
                rb.velocity = movementVector;
                Vector3 lookAtYZeroed = target.transform.position;
                lookAtYZeroed.y = gameObject.transform.position.y;
                gameObject.transform.LookAt(lookAtYZeroed, Vector3.up);
            }
        }
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
            die = true;
            deathStart = Time.time;
        }
    }
}
