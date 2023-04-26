using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FuseCharger : MonoBehaviour
{
    public bool fuseInserted = false;
    public bool audio_played = false;
    public int charge_time = 5;

    public AudioClip beginning;
    public AudioClip mid;
    public AudioClip ending;

    private GameObject fuse;
    private AudioSource speaker;
    private FusePower power;

    private bool endingClip = false;

    public void Inserted()
    {
        fuseInserted = true;
        fuse = gameObject.GetComponent<SocketWithTagCheck>().GetOldestInteractableSelected().transform.gameObject;
        speaker = fuse.GetComponent<AudioSource>();
        speaker.clip = beginning;
        speaker.Play();
        power = fuse.GetComponent<FusePower>();
        endingClip = false;
    }
    
    public void Removed()
    {
        fuseInserted = false;
        speaker.Stop();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (fuseInserted)
        {
            power.charge += Time.deltaTime/charge_time;
            
            if (power.charge > 1)
            {
                power.charge = 1;
            }

            if (!endingClip && !speaker.isPlaying)
            {
                speaker.clip = mid;
                speaker.Play();
            } else if (power.charge >= 1 - 4.671 / charge_time)
            {
                endingClip = true;
                speaker.Stop();
                speaker.clip = ending;
                speaker.Play();
            }
            
            /*
            
            if (gameObject.GetComponent<SocketWithTagCheck>().GetOldestInteractableSelected().transform.gameObject
                    .GetComponent<FusePower>().charge == 1 && audio_played == false)
            {
                gameObject.GetComponent<SocketWithTagCheck>().GetOldestInteractableSelected().transform.gameObject
                    .GetComponent<FusePower>()
            }
            
            */
            
        }
    }
}
