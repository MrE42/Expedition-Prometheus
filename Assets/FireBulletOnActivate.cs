using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPointSmall;
    public Transform spawnPointCharged;
    public float fireSpeed = 20;

    public FuseChecker sockets;
    public bool ok = false;
    public bool timer = false;

    public float BulletTime = 0;

    public float fusePrecent = 0.25f;

    public int maxDamage = 5;
    

    // Start is called before the first frame update
    void Start()
    {
        //XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        //grabbable.activated.AddListener(FireBullet);
    }

    // Update is called once per frame
    void Update()
    {
        if (sockets != null)
        {
            ok = sockets.killable && (sockets.total_charge >= 0.25f);
        }
        else
        {
            ok = true;
        }
        
        if (timer)
        {
            BulletTime += Time.deltaTime;
        }
    }

    public void BullletTimeStart(ActivateEventArgs arg)
    {
        if (ok)
        {
            timer = true;
            BulletTime = Time.deltaTime;
        }
    }
    
    public void BullletTimeEnd(DeactivateEventArgs arg)
    {
        if (ok)
        {
            timer = false;
            if (BulletTime < 0.5)
            {
                FireBullet();
            }
            else
            {
                FireChargedShot();
            }
        }
    }
    

    public void FireBullet()
    {
        if (ok)
        {
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = spawnPointSmall.position;
            spawnedBullet.transform.rotation = spawnPointSmall.rotation;
            spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPointSmall.forward * fireSpeed;
            sockets.FuseDrain(fusePrecent);
            Destroy(spawnedBullet, 5);
        }

    }
    
    public void FireChargedShot()
    {
        if (ok)
        {
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = spawnPointCharged.position;
            spawnedBullet.transform.rotation = spawnPointSmall.rotation;
            BulletTime = MathF.Abs(BulletTime);
            if (BulletTime * fusePrecent >= sockets.total_charge && BulletTime <= maxDamage)
            {
                spawnedBullet.GetComponent<BulletDamage>().damage = (int) MathF.Floor(sockets.total_charge);
                sockets.FuseDrain(sockets.total_charge);
            }
            else if (BulletTime >= maxDamage)
            {
                spawnedBullet.GetComponent<BulletDamage>().damage = maxDamage;
                sockets.FuseDrain(fusePrecent * maxDamage);
            }else
            {
                spawnedBullet.GetComponent<BulletDamage>().damage = (int) MathF.Floor(BulletTime);
                sockets.FuseDrain(fusePrecent * MathF.Floor(BulletTime));
            }
            spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPointSmall.forward * fireSpeed;
            Destroy(spawnedBullet, 5);
        }

    }
}
