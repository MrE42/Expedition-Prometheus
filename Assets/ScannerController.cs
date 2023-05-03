using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ScannerController : MonoBehaviour
{

    public LevelControl level;
    
    private GameObject handScanner;
    public float moveSpeed = 0.1f;
    
    private Vector3 scanLeft;
    private Vector3 scanRight;

    public float Offset = 0.085f;
    public float MP = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        handScanner = gameObject;
        scanLeft = new Vector3(handScanner.transform.localPosition.x, handScanner.transform.localPosition.y, handScanner.transform.localPosition.z);
        scanRight = new Vector3(handScanner.transform.localPosition.x+Offset, handScanner.transform.localPosition.y, handScanner.transform.localPosition.z);
    }
    

    // Update is called once per frame
    void Update()
    {
        if (level.gameOver)
        {
            MP += 0.01f * moveSpeed;
        } else
        {
            MP -= 0.01f * moveSpeed;
        }
        
        MP = Mathf.Clamp(MP, 0, 1);
        handScanner.transform.localPosition = Vector3.Lerp(scanLeft, scanRight, MP);

    }
    
}

