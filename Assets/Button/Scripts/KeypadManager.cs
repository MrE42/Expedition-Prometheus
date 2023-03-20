using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadManager : MonoBehaviour
{
    public GameObject screen;
    public List<int> pressOrder = new List<int>();
    public List<ButtonVR> buttons = new List<ButtonVR>();

    List<int> code = new List<int> { 1, 2, 3 };

    // Start is called before the first frame update
    void Start()
    {
        
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
            pressOrder = new List<int>();
            foreach (ButtonVR button in buttons)
            {
                button.ResetButton();
            }
        }
    }
}
