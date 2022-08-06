using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class imageEnable: MonoBehaviour
{

    public Image img;

    void Start()
    {

        img.enabled = true;

    }

    void Update()
    {

        if (GlobalVariables.online == false)
        {
            img.enabled = true;

        }

        else
        {
            img.enabled = false;
        }
           
            
    }
}