using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllButton : MonoBehaviour
{
    public GameObject handLeft;
    public GameObject handRight;
    public DoorManager doorManager;
    private bool buttonClicked = false;
    private Vector3 buttonUp;
    private Vector3 buttonDown;
    void Start()
    {
        buttonUp = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        buttonDown = new Vector3(transform.position.x, transform.position.y - .011f, transform.position.z);
    }

    void Update()
    {
        if (buttonClicked)
        {
            transform.position = buttonDown;
        }
        else
        {
            transform.position = buttonUp;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == handLeft || other.gameObject == handRight)
        {
            buttonClicked = true;
            doorManager.doorIsOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == handLeft || other.gameObject == handRight)
        {
            buttonClicked = false;
            doorManager.doorIsOpen = false;
        }
    }
}
