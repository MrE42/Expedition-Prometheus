using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class KeypadManager : MonoBehaviour
{
    public TextMeshPro keypadScreen;
    public List<int> pressOrder = new List<int>();
    public List<DoorButtonVR> buttons = new List<DoorButtonVR>();
    public List<int> code = new List<int> { 1, 3, 2, 4};
    private float lastFusePower = 0;
    public float fusePower = 0;
    public XRSocketInteractor fuseInteractor;
    public TextMeshPro tvScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DisplayCurrentCode()
    {
        keypadScreen.color = Color.white;
        List<string> strings = pressOrder.ConvertAll<string>(x => x.ToString());
        keypadScreen.text = String.Join(", ", strings);
    }

    // Update is called once per frame
    void Update()
    {
        lastFusePower = fusePower;
        if (pressOrder.Count == code.Count)
        {
            bool codesMatch = true;
            for (int i = 0; i < pressOrder.Count; i++)
            {
                if (pressOrder[i] != code[i])
                {
                    codesMatch = false;
                }
            }
            //Debug.Log("Code is: " + codesMatch);
            if (codesMatch)
            {
                keypadScreen.color = Color.green;
                keypadScreen.text = "Accepted";
                tvScreen.text = "";
            }
            else
            {
                keypadScreen.color = Color.red;
                keypadScreen.text = "Rejected";
            }
            pressOrder = new List<int>();
            foreach (DoorButtonVR button in buttons)
            {
                button.ResetButton();
            }
        }

        if (fuseInteractor.hasSelection) // If fuse is plugged into socket
        {
            fusePower = fuseInteractor.GetOldestInteractableSelected().transform.gameObject.GetComponent<FusePower>().charge;
        }
        else
        {
            fusePower = 0;
        }

        if (lastFusePower==0 && fusePower>0) // When a new fuse is plugged into socket
        {
            // Change code on keypad
            System.Random rand = new System.Random();
            for (int i = 0; i < code.Count; i++)
            {
                code[i] = rand.Next(0, 10); // Generate a random number between 0 and 9
            }
            // Change color of text on tv screen to white
            tvScreen.color = Color.white;
            // Set text
            List<string> strings = code.ConvertAll<string>(x => x.ToString());
            tvScreen.text = "Enter " + String.Join(", ", strings);
        }
    }

    public void KeyFuseDrain(float scalar = 1f)
    {
        fuseInteractor.GetOldestInteractableSelected().transform.gameObject.GetComponent<FusePower>().charge -=
            Time.deltaTime / scalar;
    }
}
