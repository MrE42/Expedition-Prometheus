using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FuseClicker : MonoBehaviour
{
    
    private bool click = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<SocketWithTagCheck>().hasSelection && !click)
        {
            click = true;
            gameObject.GetComponent<SocketWithTagCheck>().GetOldestInteractableSelected().transform.gameObject.GetComponent<AudioSource>().Play();
        } else if (!gameObject.GetComponent<SocketWithTagCheck>().hasSelection)
        {
            click = false;
        }
    }
}
