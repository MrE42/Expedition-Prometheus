using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject upperDoor;
    public GameObject lowerDoor;
    public bool doorIsOpen = false;
    public float doorSpeed = 1;

    private Vector3 doorUpperClosedPose = new Vector3(0.08296894f, 0.08457943f, -0.01763998f);
    private Vector3 doorUpperOpenPose = new Vector3(0.08296894f, 0.2295f, -0.01763998f);

    private Vector3 doorLowerClosedPose = new Vector3(0.08296894f, 0.1401947f, -0.01763998f);
    private Vector3 doorLowerOpenPose = new Vector3(0.08296894f, -0.0011f, -0.01763998f);

    // Start is called before the first frame update
    void Start()
    {

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
        if (upperDoor.transform.position.y < doorUpperOpenPose.y)
        {
            upperDoor.transform.position = new Vector3(upperDoor.transform.position.x, upperDoor.transform.position.y + (doorSpeed * Time.deltaTime), upperDoor.transform.position.z);
        }
        if (lowerDoor.transform.position.y > doorLowerOpenPose.y)
        {
            lowerDoor.transform.position = new Vector3(lowerDoor.transform.position.x, lowerDoor.transform.position.y - (doorSpeed * Time.deltaTime), lowerDoor.transform.position.z);
        }
    }
    void CloseDoor()
    {
        if (upperDoor.transform.position.y > doorUpperClosedPose.y)
        {
            upperDoor.transform.position = new Vector3(upperDoor.transform.position.x, upperDoor.transform.position.y - (doorSpeed * Time.deltaTime), upperDoor.transform.position.z);
        }
        if (lowerDoor.transform.position.y < doorLowerClosedPose.y)
        {
            lowerDoor.transform.position = new Vector3(lowerDoor.transform.position.x, lowerDoor.transform.position.y + (doorSpeed * Time.deltaTime), lowerDoor.transform.position.z);
        }
    }
}
