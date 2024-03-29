using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;

public class PodManager : MonoBehaviour
{

    public LevelControl level;
    public XRSocketInteractor podSocket;
    public int endPhase = 0;

    private GameObject transport;
    public float moveSpeed = 0.1f;
    
    private Vector3 transportDown;
    private Vector3 transportUp;

    public float transportOffset = 0.085f;
    private float podStartMovement = 0;
    public float transportMP = 0;

    public StartRoundButton endButton;
    public GameObject buttonText;

    public GameObject podShip;
    public Transform podPosition;
    public float launchVelocity = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        transport = gameObject;
        transportDown = new Vector3(transport.transform.localPosition.x, transport.transform.localPosition.y, transport.transform.localPosition.z);
        transportUp = new Vector3(transport.transform.localPosition.x, transport.transform.localPosition.y+transportOffset, transport.transform.localPosition.z);
    }





    // Update is called once per frame
    void Update()
    {
        if (level.currentWaveNumber + 1 == level.finalWave && endPhase == 0)
        {
            endPhase = 1;
        }

        if (endPhase == 1 && podSocket.hasSelection)
        {
            endPhase = 2;
        }

        if (endPhase == 2 && transportMP == 0)
        {
            endPhase = 3;
            buttonText.GetComponent<TextMeshPro>().text = "Press To Launch Seed";
        }

        if (endPhase == 3 && endButton.buttonClicked || endPhase == 5)
        {
            endPhase = 4;
            //Fire the seed
            GameObject ship = Instantiate(podShip);
            ship.transform.position = podPosition.position;
            ship.transform.rotation = podPosition.rotation;
            ship.GetComponent<Rigidbody>().velocity = podPosition.forward * launchVelocity;
            Destroy(ship, 60);
        }

        if (endPhase == 4)
        {
            level.gameOver = true;
        }

        if (endPhase == 1)
        {
            transportMP += 0.01f*moveSpeed;
        } else if (endPhase == 2)
        {
            transportMP -= 0.01f * moveSpeed;
        }

        if (endPhase == 1 || endPhase == 2)
        {
            transportMP = Mathf.Clamp(transportMP, 0, 1);
            transport.transform.localPosition = Vector3.Lerp(transportDown, transportUp, transportMP);
        }

    }
    
}
