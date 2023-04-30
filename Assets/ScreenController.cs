using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{

    public Material blankScreen;
    public Material displayText;

    public LevelControl level;

    public int wave;

    private AudioSource speaker;

    public AudioClip Hello;

    public bool nearby = false;
    private bool firstDoor = true;
    private bool firstPower = true;

    private int cc = 0;
    
    public AudioClip Alive;
    public AudioClip Unlikely;
    public AudioClip Sensors;

    public AudioClip Scans;
    
    public AudioClip Doors;

    public AudioClip powerShot;
    // Start is called before the first frame update
    void Start()
    {
        speaker = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (speaker.isPlaying)
        {
            gameObject.GetComponent<MeshRenderer>().material = displayText;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = blankScreen;
        }
        
        
        wave = level.currentWaveNumber + 1;

        if (wave == 0)
        {
            if (cc == 0)
            {
                cc = 1;
                speaker.clip = Hello;
                speaker.Play();
            } else if (cc == 1 && !speaker.isPlaying && nearby)
            {
                cc = 2;
                speaker.clip = Unlikely;
                speaker.Play();
            } else if (cc == 2 && !speaker.isPlaying)
            {
                cc = 3;
                speaker.clip = Sensors;
                speaker.Play();
            }
        }
    }

    public void DoorPress()
    {
        if (firstDoor)
        {
            speaker.clip = Doors;
            speaker.Play();
        }

        firstDoor = false;
    }
    
    public void PowerShot()
    {
        if (firstPower)
        {
            speaker.clip = powerShot;
            speaker.Play();
        }

        firstPower = false;
    }
    
}
