using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{

    public List<AudioClip> Growls;

    public float growlTime = 0;
    public float growlTimer = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (growlTime >= growlTimer)
        {
            growlTime = 0;
            System.Random rand = new System.Random();
            int number = rand.Next(Growls.Count);
            gameObject.GetComponent<AudioSource>().clip = Growls[number];
            gameObject.GetComponent<AudioSource>().Play();
        }
        growlTime += Time.deltaTime;
    }
}
