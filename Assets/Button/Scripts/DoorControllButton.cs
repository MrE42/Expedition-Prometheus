using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllButton : MonoBehaviour
{
    public ScreenController screen;
    public GameObject handLeft;
    public GameObject handRight;
    public DoorManager doorManager;
    private bool buttonClicked = false;
    private Vector3 buttonUp;
    private Vector3 buttonDown;
    void Start()
    {
        buttonUp = gameObject.transform.position;
        buttonDown = new Vector3(buttonUp.x,buttonUp.y-.01f,buttonUp.z);
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
                doorManager.doorIsOpen = !doorManager.doorIsOpen;
            }
            gameObject.transform.position = buttonDown;
            if (screen != null)
            {
                screen.DoorPress();
            }
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
