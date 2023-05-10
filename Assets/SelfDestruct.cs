using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SelfDestruct : MonoBehaviour
{
    public LevelControl levelControl;
    public ScreenController screen;
    public GameObject handLeft;
    public GameObject handRight;
    public bool buttonClicked = false;
    private Vector3 buttonUp;
    private Vector3 buttonDown;

    void Start()
    {
        buttonUp = gameObject.transform.position;
        buttonDown = new Vector3(buttonUp.x, buttonUp.y - .01f, buttonUp.z);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == handLeft || other.gameObject == handRight)
        {
            if (!buttonClicked)
            {
                buttonClicked = true;
                if (levelControl.gameOver)
                {
                    screen.gameObject.GetComponent<VideoPlayer>().Play();
                    screen.selfDestruct = true;
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
