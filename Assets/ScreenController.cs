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

    public AudioClip Alive;
    public AudioClip Unlikely;
    public AudioClip Sensors;
    public AudioClip Keypad;

    public AudioClip Scans;
    public AudioClip Endless;
    public AudioClip Halfway;
    public AudioClip Mutating;
    public AudioClip Warning;
    public AudioClip Instructions;
    public AudioClip Reached;
    
    public AudioClip Doors;

    public AudioClip powerShot;

    public bool selfDestruct = false;

    private float startTime = 0;
    public float startTimer = 10;
    
    private AudioClip next_clip = null;
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

        if (next_clip is null && level.gameOver == selfDestruct)
        {
            startTime += Time.deltaTime;
        }

        if (startTime >= startTimer)
        {
            startTime = 0;
            if (!level.gameOver)
            {
                next_clip = Hello;
            }
            else
            {
                //Explosion / Game Ending Sound
            }
        }
        
        wave = level.currentWaveNumber + 1;

        if (!speaker.isPlaying)
        {
            if (wave == 0)
            {
                if (next_clip == Hello)
                {
                    Play();
                    next_clip = Unlikely;
                } else if (next_clip == Unlikely && nearby)
                {
                    Play();
                    next_clip = Sensors;
                } else if (next_clip == Sensors)
                {
                    Play();
                    next_clip = Keypad;
                } else if (next_clip == Keypad)
                {
                    Play();
                    next_clip = Scans;
                }
            } else if (wave == 1 && next_clip == Scans)
            {
                Play();
                next_clip = Endless;
            } else if (wave == 3 && next_clip == Endless)
            {
                Play();
                next_clip = Halfway;
            } else if (wave == 5 && next_clip == Halfway)
            {
                Play();
                next_clip = Mutating;
            } else if (wave == 7 && next_clip == Mutating)
            {
                Play();
                next_clip = Warning;
            } else if (wave == 9 && next_clip == Warning)
            {
                Play();
                next_clip = Instructions;
            } else if (wave == 10 && next_clip == Instructions)
            {
                Play();
                next_clip = Reached;
            } else if (level.gameOver && next_clip == Reached)
            {
                Play();
                next_clip = null;
                startTime = 0;
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

    private void Play()
    {
        speaker.clip = next_clip;
        speaker.Play();
    }
    
}
