using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class KeypadManager : MonoBehaviour
{
    public TextMeshPro screen;
    public List<int> pressOrder = new List<int>();
    public List<DoorButtonVR> buttons = new List<DoorButtonVR>();
    public List<int> code = new List<int> { 1, 3, 2, 4};
    public float fusePower = 0;
    public XRSocketInteractor fuseInteractor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DisplayCurrentCode()
    {
        screen.color = Color.white;
        List<string> strings = pressOrder.ConvertAll<string>(x => x.ToString());
        screen.text = String.Join(", ", strings);
    }

    // Update is called once per frame
    void Update()
    {
        if (pressOrder.Count==code.Count)
        {
            bool codesMatch = true;
            for (int i=0; i<pressOrder.Count; i++)
            {
                if (pressOrder[i]!=code[i])
                {
                    codesMatch = false;
                }
            }
            Debug.Log("Code is: "+codesMatch);
            if (codesMatch)
            {
                screen.color = Color.green;
                screen.text = "Accepted";
            }
            else
            {
                screen.color = Color.red;
                screen.text = "Rejected";
            }
            pressOrder = new List<int>();
            foreach (DoorButtonVR button in buttons)
            {
                button.ResetButton();
            }
        }
        
        /*
        
        if () // TODO: When the fuse is plugged into its socket
        {
            // TODO: Display code on TV, change code on keypad, and wait until that code is entered before reactivating door
            // NOTE: you don't have to code anything here I can write this part.
        }
        */
        if (fuseInteractor.hasSelection) // TODO: Fuse is plugged into socket
        {
            fusePower = fuseInteractor.GetOldestInteractableSelected().transform.gameObject.GetComponent<FusePower>().charge;
        } else
        {
            fusePower = 0;
        }
    }

    public void KeyFuseDrain(float scalar = 1f)
    {
        fuseInteractor.GetOldestInteractableSelected().transform.gameObject.GetComponent<FusePower>().charge -=
            Time.deltaTime / scalar;
    }
}
