using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNear : MonoBehaviour
{
    public ScreenController screen;
    public GameObject player;

    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 1)
        {
            screen.nearby = true;
        }
    }
}
