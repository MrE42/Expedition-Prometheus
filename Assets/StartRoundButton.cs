using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoundButton : MonoBehaviour
{
    public LevelControl levelControl;
    public GameObject handLeft;
    public GameObject handRight;
    private bool buttonClicked = false;
    private Vector3 buttonUp;
    private Vector3 buttonDown;

    void Start()
    {
        buttonUp = gameObject.transform.position;
        buttonDown = new Vector3(buttonUp.x, buttonUp.y - .01f, buttonUp.z);
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == handLeft || other.gameObject == handRight)
        {
            if (!buttonClicked)
            {
                buttonClicked = true;
                if (levelControl.currentWaveNumber == -1)
                {
                    levelControl.startWave = true;
                }
            }
            gameObject.transform.position = buttonDown;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == handLeft || other.gameObject == handRight)
        {
            buttonClicked = false;
            gameObject.transform.position = buttonUp;
        }
    }
}