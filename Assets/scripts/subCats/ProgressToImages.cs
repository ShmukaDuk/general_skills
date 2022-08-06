using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressToImages : MonoBehaviour
{
    public GameObject[] image = new GameObject[4];
    public GameObject[] image2 = new GameObject[4];

    public void subCat_4()
    {
        SetImagesActive(12, 15);
        Debug.Log("Setting images");
    }
    public void subCat_3()
    {
        SetImagesActive(8, 11);
    }
    public void subCat_2()
    {
        SetImagesActive(4, 7);
    }
    public void subCat_1()
    {
        SetImagesActive(0, 3);
    }

    string OnesAndZeros = "";
    // Start is called before the first frame update
    public void SetImagesActive(int n, int m)
    {
        
        int j = 0;
        for (int i = n; i <= m; i++)
        {
            //Debug.Log(i + " " + n + " " + m);
            if (GlobalVariables.progressData[i])
            {
                OnesAndZeros += "1";
            }
            else
            {
                OnesAndZeros += "0";
            }
            //Debug.Log(OnesAndZeros);

            if (GlobalVariables.progressData[i])
            {
                //Debug.Log(GlobalVariables.progressData[i]);
                //Debug.Log(j);
                image[j].SetActive(true);
                image2[j].SetActive(false);

            }
            else
            {
                image[j].SetActive(false);
                image2[j].SetActive(true);
            }
                
            j++;            
        }    
    }
   
}
