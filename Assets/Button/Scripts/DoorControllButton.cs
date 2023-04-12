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
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == handLeft || other.gameObject == handRight)
        {
                buttonClicked = false;
        }
    }
}
