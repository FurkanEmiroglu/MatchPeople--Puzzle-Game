using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resolution : MonoBehaviour
{

    private bool isCalledOnce = true;
    void Start()
    {
        if (isCalledOnce)
        {
            Screen.SetResolution(Screen.currentResolution.width / 2, Screen.currentResolution.height / 2, true);
            isCalledOnce = false;
        }
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
