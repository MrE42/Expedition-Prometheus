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

    public ParticleSystem chargingParticles;
    public bool charging = false;

    public ParticleSystem regularBlast;
    public ParticleSystem chargedBlast;

    public AudioClip regularClip;
    public AudioClip chargedClip;
    public AudioClip chargingClip;
    
    private AudioSource speaker;

    public ScreenController screen;
    // Start is called before the first frame update
    void Start()
    {
        //XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        //grabbable.activated.AddListener(FireBullet);
        speaker = gameObject.GetComponent<AudioSource>();
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
            if (BulletTime >= 1 && charging is false)
            {
                charging = true;
                chargingParticles.Play();
                speaker.Stop();
                speaker.clip = chargingClip;
                speaker.Play();
            }
        }
    }

    public void BullletTimeStart(ActivateEventArgs arg)
    {
        if (ok)
        {
            timer = true;
            BulletTime = Time.deltaTime;
            regularBlast.Stop();
            chargedBlast.Stop();
        }
    }
    
    public void BullletTimeEnd(DeactivateEventArgs arg)
    {
        if (ok)
        {
            timer = false;
            if (!charging)
            {
                FireBullet();
            }
            else
            {
                FireChargedShot();
            }
            charging = false;
        }
    }
    

    public void FireBullet()
    {
        speaker.Stop();
        speaker.clip = regularClip;
        speaker.Play();
        regularBlast.Play();
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.GetComponent<BulletDamage>().Generate(1);
        spawnedBullet.transform.position = spawnPointSmall.position;
        spawnedBullet.transform.rotation = spawnPointSmall.rotation;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPointSmall.forward * fireSpeed;
        sockets.FuseDrain(fusePrecent);
        Destroy(spawnedBullet, 5);

    }
    
    public void FireChargedShot()
    {
        if (screen != null)
        {
            screen.PowerShot();
        }
        speaker.Stop();
        speaker.clip = chargedClip;
        speaker.Play();
        chargingParticles.Stop();
        chargedBlast.Play();
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPointCharged.position;
        spawnedBullet.transform.rotation = spawnPointSmall.rotation;
        BulletTime = MathF.Abs(BulletTime);
        if (BulletTime * fusePrecent >= sockets.total_charge && BulletTime <= maxDamage)
        {
            spawnedBullet.GetComponent<BulletDamage>().Generate((int) MathF.Floor(sockets.total_charge));
            sockets.FuseDrain(sockets.total_charge);
        }
        else if (BulletTime >= maxDamage)
        {
            spawnedBullet.GetComponent<BulletDamage>().Generate(maxDamage);
            sockets.FuseDrain(fusePrecent * maxDamage);
        }else
        {
            spawnedBullet.GetComponent<BulletDamage>().Generate((int) MathF.Floor(BulletTime));
            sockets.FuseDrain(fusePrecent * MathF.Floor(BulletTime));
        }
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPointSmall.forward * fireSpeed;
        Destroy(spawnedBullet, 5);

    }
}
