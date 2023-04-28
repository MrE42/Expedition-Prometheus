using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPowerBars : MonoBehaviour
{
    public KeypadManager keypadManager;
    public float brightness = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, keypadManager.fusePower, 0);
        gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Vector4(0, keypadManager.fusePower, 0, 0) * brightness);
    }
}
