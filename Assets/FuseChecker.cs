using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FuseChecker : MonoBehaviour
{

    public List<XRSocketInteractor> interactors = new List<XRSocketInteractor>();

    public int fusesInserted = 0;
    public bool killable = false;
    public float total_charge = 0;
    public int requiredFuses = 5;

    // Update is called once per frame
    void Update()
    {
        fusesInserted = 0;
        total_charge = 0;
        for (int i = 0; i < interactors.Count; i++)
        {
            if (interactors[i].hasSelection)
            {
                fusesInserted++;
                total_charge += interactors[i].GetOldestInteractableSelected().transform.gameObject.GetComponent<FusePower>().charge;
            }
        }
        if (fusesInserted >= requiredFuses)
        {
            killable = true;
        } else
        {
            killable = false;
        }
    }
}
