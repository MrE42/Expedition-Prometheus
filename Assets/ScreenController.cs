using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ScreenController : MonoBehaviour
{

    public Material blankScreen;
    public Material displayText;

    public LevelControl level;

    public int wave;

    public AudioSource speaker;

    public AudioClip Hello;

    public bool nearby = false;
    private bool firstDoor = true;
    private bool firstPower = true;

    public int cc = 0;
    
    public AudioClip Alive;
    public AudioClip Unlikely;
    public AudioClip Sensors;

    public AudioClip Scans;
    public AudioClip Endless;
    public AudioClip Halfway;
    public AudioClip Mutating;
    public AudioClip Warning;
    public AudioClip Reached;
    
    public AudioClip Doors;

    public AudioClip powerShot;

    public bool selfDestruct = false;
    // Start is called before the first frame update
    void Start()
    {
        //speaker = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selfDestruct)
        {
            if (!gameObject.GetComponent<VideoPlayer>().isPlaying)
            {
                //Explode & end game!
            }
        } else if (speaker.isPlaying)
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
        } else if (wave == 1 && !speaker.isPlaying)
        {
            speaker.clip = Scans;
            speaker.Play();
        } else if (wave == 3 && !speaker.isPlaying)
        {
            speaker.clip = Endless;
            speaker.Play();
        } else if (wave == 5 && !speaker.isPlaying)
        {
            speaker.clip = Halfway;
            speaker.Play();
        } else if (wave == 7 && !speaker.isPlaying)
        {
            speaker.clip = Mutating;
            speaker.Play();
        } else if (wave == 10 && !speaker.isPlaying)
        {
            speaker.clip = Endless;
            speaker.Play();
        } else if (!speaker.isPlaying && level.gameOver)
        {
            speaker.clip = Reached;
            speaker.Play();
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
