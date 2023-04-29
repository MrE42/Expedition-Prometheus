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
        float percentage = keypadManager.fusePower;
        Color startColor = Color.red;
        Color middleColor = Color.yellow;
        Color endColor = Color.green;
        Color lerpedColor;
        if (percentage < 0.5f) {
            lerpedColor = Color.Lerp(startColor, middleColor, percentage * 2f);
        } else {
            lerpedColor = Color.Lerp(middleColor, endColor, (percentage - 0.5f) * 2f);
        }
        gameObject.GetComponent<MeshRenderer>().material.color = lerpedColor;
        gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", lerpedColor * brightness);
    }
}
