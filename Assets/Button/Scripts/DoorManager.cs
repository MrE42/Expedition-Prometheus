using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject upperDoor;
    public GameObject lowerDoor;
    public bool doorIsOpen = false;
    public float doorSpeed = 1;

    private Vector3 doorUpperClosedPose;
    private Vector3 doorUpperOpenPose;

    private Vector3 doorLowerClosedPose;
    private Vector3 doorLowerOpenPose;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 doorUpperClosedPose = new Vector3(upperDoor.transform.localPosition.x, upperDoor.transform.localPosition.y, upperDoor.transform.localPosition.z);
        Vector3 doorUpperOpenPose = new Vector3(lowerDoor.transform.localPosition.x, lowerDoor.transform.localPosition.y, lowerDoor.transform.localPosition.z);

        Vector3 doorLowerClosedPose = new Vector3(lowerDoor.transform.localPosition.x, lowerDoor.transform.localPosition.y, lowerDoor.transform.localPosition.z);
        Vector3 doorLowerOpenPose = new Vector3(lowerDoor.transform.localPosition.x, lowerDoor.transform.localPosition.y, lowerDoor.transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (doorIsOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        upperDoor.transform.localPosition = doorUpperOpenPose;
        lowerDoor.transform.localPosition = doorLowerOpenPose;
        /*
        if (upperDoor.transform.position.y < doorUpperOpenPose.y)
        {
            upperDoor.transform.position = new Vector3(upperDoor.transform.position.x, upperDoor.transform.position.y + (doorSpeed * Time.deltaTime), upperDoor.transform.position.z);
        }
        if (lowerDoor.transform.position.y > doorLowerOpenPose.y)
        {
            lowerDoor.transform.position = new Vector3(lowerDoor.transform.position.x, lowerDoor.transform.position.y - (doorSpeed * Time.deltaTime), lowerDoor.transform.position.z);
        }*/
    }
    void CloseDoor()
    {
        upperDoor.transform.localPosition = doorUpperClosedPose;
        lowerDoor.transform.localPosition = doorLowerClosedPose;
        /*
        if (upperDoor.transform.position.y > doorUpperClosedPose.y)
        {
            upperDoor.transform.position = new Vector3(upperDoor.transform.position.x, upperDoor.transform.position.y - (doorSpeed * Time.deltaTime), upperDoor.transform.position.z);
        }
        if (lowerDoor.transform.position.y < doorLowerClosedPose.y)
        {
            lowerDoor.transform.position = new Vector3(lowerDoor.transform.position.x, lowerDoor.transform.position.y + (doorSpeed * Time.deltaTime), lowerDoor.transform.position.z);
        }*/
    }
}
