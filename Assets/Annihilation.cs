using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Annihilation : MonoBehaviour
{
    public float timer;
    public float setTime;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= setTime)
        {
            Destroy(gameObject);
        }
    }
}
