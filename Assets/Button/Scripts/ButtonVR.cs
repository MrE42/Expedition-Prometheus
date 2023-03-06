/**************************************************
Copyright : Copyright (c) RealaryVR. All rights reserved.
Description: Script for VR Button functionality.
***************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    public GameObject handLeft;
    public GameObject handRight;
    public UnityEvent onPress;
    public UnityEvent onRelease;

    GameObject presser;
    AudioSource sound;
    bool isPressed;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject==handLeft || other.gameObject==handRight)
        {
            if (!isPressed)
            {
                gameObject.transform.localPosition += new Vector3(-0.001f, 0, 0);
                presser = other.gameObject;
                onPress.Invoke();
                sound.Play();
                isPressed = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            gameObject.transform.localPosition += new Vector3(0.001f, 0, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }
    /*
    public void SpawnSphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sphere.transform.localPosition = new Vector3(0, 1, 2);
        sphere.AddComponent<Rigidbody>();
    }*/
}
