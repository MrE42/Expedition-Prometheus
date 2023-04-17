using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FuseCharger : MonoBehaviour
{
    public bool fuseInserted = false;

    public void Inserted()
    {
        fuseInserted = true;
    }
    
    public void Removed()
    {
        fuseInserted = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (fuseInserted)
        {
            gameObject.GetComponent<SocketWithTagCheck>().GetOldestInteractableSelected().transform.gameObject.GetComponent<FusePower>().charge += Time.deltaTime/5;
            if (gameObject.GetComponent<SocketWithTagCheck>().GetOldestInteractableSelected().transform.gameObject
                    .GetComponent<FusePower>().charge > 1)
            {
                gameObject.GetComponent<SocketWithTagCheck>().GetOldestInteractableSelected().transform.gameObject
                    .GetComponent<FusePower>().charge = 1;
            }
            
        }
    }
}
