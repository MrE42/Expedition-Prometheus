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
            Rigidbody[] bodies = gameObject.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody chRB in bodies)
            {
                chRB.isKinematic = false;
            }
            anim.enabled = false;
        }
        else
        {
            if (vector2DDistance(gameObject.transform.position, target.transform.position) < attackDistance)
            {
                anim.CrossFade("Attack1", 1.5f);
                rb.velocity = new Vector3(0,0,0);
            }
            else
            {
                anim.CrossFade("Walk", 1.5f);
                Vector3 enemyToTarget = target.transform.position - gameObject.transform.position;
                Vector3 movementVector = enemyToTarget.normalized * walkingSpeed * Time.deltaTime;
                movementVector.y = 0;
                //gameObject.transform.position += movementVector;
                rb.velocity = movementVector;
            }
        }
    }

    private float vector2DDistance(Vector3 v1, Vector3 v2)
    {
        float xDiff = v1.x - v2.x;
        float zDiff = v1.z - v2.z;
        return Mathf.Sqrt((xDiff * xDiff) + (zDiff * zDiff));
    }
}
