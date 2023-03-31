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

    public float doorOffset = 0.14f;
    private float doorStartMovement = Time.time;
    public float doorMovementPercentage = 0;
    private bool lastDoorIsOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        doorUpperClosedPose = new Vector3(upperDoor.transform.localPosition.x, upperDoor.transform.localPosition.y, upperDoor.transform.localPosition.z);
        doorUpperOpenPose = new Vector3(upperDoor.transform.localPosition.x, upperDoor.transform.localPosition.y+doorOffset, upperDoor.transform.localPosition.z);

        doorLowerClosedPose = new Vector3(lowerDoor.transform.localPosition.x, lowerDoor.transform.localPosition.y, lowerDoor.transform.localPosition.z);
        doorLowerOpenPose = new Vector3(lowerDoor.transform.localPosition.x, lowerDoor.transform.localPosition.y-doorOffset, lowerDoor.transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (doorIsOpen)
        {
            doorMovementPercentage -= 0.01f*doorSpeed;
            lastDoorIsOpen = doorIsOpen;
            doorMovementPercentage = Mathf.Clamp(doorMovementPercentage, 0, 1);
            upperDoor.transform.localPosition = Vector3.Lerp(doorUpperClosedPose, doorUpperOpenPose, doorMovementPercentage);
            lowerDoor.transform.localPosition = Vector3.Lerp(doorLowerClosedPose, doorLowerOpenPose, doorMovementPercentage);
        }
        else
        {
            doorMovementPercentage += 0.01f*doorSpeed;
            lastDoorIsOpen = doorIsOpen;
            doorMovementPercentage = Mathf.Clamp(doorMovementPercentage, 0, 1);
            upperDoor.transform.localPosition = Vector3.Lerp(doorUpperClosedPose, doorUpperOpenPose, doorMovementPercentage);
            lowerDoor.transform.localPosition = Vector3.Lerp(doorLowerClosedPose, doorLowerOpenPose, doorMovementPercentage);
        }
    }

    void OpenDoor()
    {
        upperDoor.transform.localPosition = Vector3.Lerp(doorUpperClosedPose, doorUpperOpenPose, doorMovementPercentage);
        lowerDoor.transform.localPosition = Vector3.Lerp(doorLowerClosedPose, doorLowerOpenPose, doorMovementPercentage); // eg 5.1-5 then the other side needs to be .9
        //upperDoor.transform.localPosition = Vector3.Lerp(upperDoor.transform.position, doorUpperOpenPose, Time.time-doorStartMovement);
        //lowerDoor.transform.localPosition = Vector3.Lerp(lowerDoor.transform.position, doorLowerOpenPose, Time.time-doorStartMovement);
    }
    void CloseDoor()
    {
        upperDoor.transform.localPosition = Vector3.Lerp(doorUpperOpenPose, doorUpperClosedPose, doorMovementPercentage);
        lowerDoor.transform.localPosition = Vector3.Lerp(doorLowerOpenPose, doorLowerClosedPose, doorMovementPercentage);
        //upperDoor.transform.localPosition = Vector3.Lerp(upperDoor.transform.position, doorUpperClosedPose, Time.time - doorStartMovement);
        //lowerDoor.transform.localPosition = Vector3.Lerp(lowerDoor.transform.position, doorLowerClosedPose, Time.time - doorStartMovement);
    }
}
