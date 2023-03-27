using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllButton : MonoBehaviour
{
    public GameObject handLeft;
    public GameObject handRight;
    public DoorManager doorManager;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == handLeft || other.gameObject == handRight)
        {
            doorManager.doorIsOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == handLeft || other.gameObject == handRight)
        {
            doorManager.doorIsOpen = false;
        }
    }
}
