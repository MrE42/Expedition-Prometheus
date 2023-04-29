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
    public bool fuseInserted = false;
    public float fusePower = 1;
    public XRSocketInteractor fuseInteractor;
    public TextMeshPro tvScreen;
    public bool allowClosing = false;

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
        
        if (pressOrder.Count == code.Count) // The code entered matches the length of the desired code
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
                allowClosing = true;
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
        
        if (!fuseInteractor.hasSelection) // If fuse isnt plugged into socket and door doesn't need to be reset
        {
            fuseInserted = false;
        } else if (fuseInteractor.hasSelection && !fuseInserted) // When a new fuse is plugged into socket
        {
            fuseInserted = true;
            allowClosing = false;
            // Change code on keypad
            System.Random rand = new System.Random();
            for (int i = 0; i < code.Count; i++)
            {
                int randNum = rand.Next(1, 10); // Generate a random number between 1 and 9
                while (code.Contains(randNum))
                {
                    randNum = rand.Next(1, 10);
                }
                code[i] = randNum;
            }
            // Change color of text on tv screen to white
            tvScreen.color = Color.white;
            // Set text
            List<string> strings = code.ConvertAll<string>(x => x.ToString());
            tvScreen.text = "Enter " + String.Join(", ", strings) + " To Reactivate Door";
        }

        if (fuseInteractor.hasSelection)
        {
            fusePower = fuseInteractor.GetOldestInteractableSelected().transform.gameObject.GetComponent<FusePower>().charge;
        }
    }

    public void KeyFuseDrain(float scalar = 1f)
    {
        fuseInteractor.GetOldestInteractableSelected().transform.gameObject.GetComponent<FusePower>().charge -=
            Time.deltaTime / scalar;
    }
}
