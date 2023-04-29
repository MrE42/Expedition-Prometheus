using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class FuseColorUpdate : MonoBehaviour
{
    public float brightness = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float percentage = gameObject.transform.parent.gameObject.GetComponent<FusePower>().charge;
        Color startColor = Color.black;
        Color secondColor = Color.red;
        Color thirdColor = Color.yellow;
        Color endColor = Color.green;
        Color lerpedColor;
        if (percentage < 0.33f) {
            lerpedColor = Color.Lerp(startColor, secondColor, percentage / 0.33f);
        } else if (percentage < 0.66f) {
            lerpedColor = Color.Lerp(secondColor, thirdColor, (percentage - 0.33f) / 0.33f);
        } else {
            lerpedColor = Color.Lerp(thirdColor, endColor, (percentage - 0.66f) / 0.33f);
        }
        gameObject.GetComponent<MeshRenderer>().material.color = lerpedColor;
        gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", lerpedColor * brightness);
    }
}
