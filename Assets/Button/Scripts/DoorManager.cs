using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject upperDoor;
    public GameObject lowerDoor;
    public bool doorIsOpen = false;
    public float doorSpeed = 1;
    public KeypadManager keypadManager;
    public float fuseTime = 20;

    private Vector3 doorUpperClosedPose;
    private Vector3 doorUpperOpenPose;

    private Vector3 doorLowerClosedPose;
    private Vector3 doorLowerOpenPose;

    public float doorOffset = 0.14f;
    private float doorStartMovement = 0;
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
            if (keypadManager.fusePower > 0 && keypadManager.allowClosing) // Door fuse has power in it and is plugged in
            {
                doorMovementPercentage -= 0.01f*doorSpeed;
                doorMovementPercentage = Mathf.Clamp(doorMovementPercentage, 0, 1);
                upperDoor.transform.localPosition = Vector3.Lerp(doorUpperClosedPose, doorUpperOpenPose, doorMovementPercentage);
                lowerDoor.transform.localPosition = Vector3.Lerp(doorLowerClosedPose, doorLowerOpenPose, doorMovementPercentage);
                keypadManager.KeyFuseDrain(fuseTime); // Drain the fuse on this doors keypad
            } else {
                doorIsOpen = false;
            }
        }
        else
        {
            doorMovementPercentage += 0.01f * doorSpeed;
            doorMovementPercentage = Mathf.Clamp(doorMovementPercentage, 0, 1);
            upperDoor.transform.localPosition = Vector3.Lerp(doorUpperClosedPose, doorUpperOpenPose, doorMovementPercentage);
            lowerDoor.transform.localPosition = Vector3.Lerp(doorLowerClosedPose, doorLowerOpenPose, doorMovementPercentage);
        }
    }
}
