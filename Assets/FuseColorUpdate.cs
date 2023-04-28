using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class FuseColorUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, gameObject.transform.parent.gameObject.GetComponent<FusePower>().charge, 0);
        gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Vector4(0, gameObject.transform.parent.gameObject.GetComponent<FusePower>().charge, 0, 0) * 5);
    }
}
