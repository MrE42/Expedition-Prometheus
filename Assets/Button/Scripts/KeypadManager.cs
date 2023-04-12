using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeypadManager : MonoBehaviour
{
    public TextMeshPro screen;
    public List<int> pressOrder = new List<int>();
    public List<DoorButtonVR> buttons = new List<DoorButtonVR>();

    public List<int> code = new List<int> { 1, 3, 2, 4};

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
    }
}
