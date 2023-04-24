using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage = 1;
    private GameObject shotType;
    public GameObject regularShot;
    public GameObject chargedShot;
    public void Generate(int d)
    {
        damage = d;
        if (damage == 1)
        {
            shotType = regularShot;
        }
        else
        {
            shotType = chargedShot;
        }
        shotType.GetComponent<ParticleSystem>().Play();
    }
}
