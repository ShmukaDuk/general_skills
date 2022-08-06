using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogger : MonoBehaviour
{
    // Start is called before the first frame update
    public void doTheClick()
    {
        for (int i = 0; i <= GlobalVariables.progressData.Length - 1; i++)
        {
            Debug.Log(GlobalVariables.progressData[i]);
        }

    }
       
        
}
