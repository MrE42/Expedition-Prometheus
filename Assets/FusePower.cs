using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusePower : MonoBehaviour
{

    public float charge = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (charge < 0)
        {
            charge = 0;
        }
    }
    
}
