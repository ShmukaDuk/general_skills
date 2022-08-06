using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;

public class playerProgress : MonoBehaviour
{
    

    public bool[] stuffDone = new bool[16];

    public static string serverAddress = GlobalVariables.serverAddress + "/requestData" + "//"; //+ GlobalVariables.username;
    public void requestDataWithGlobalUsername()
    {
        string userName = GlobalVariables.username;
        RequestData(userName);
        Debug.Log("username form global: "  + userName);
    }
    public void RequestData(string userName)
    {
        RequestDataAPI(serverAddress + userName);
    }

    async private void RequestDataAPI(string url)
    {
        Debug.Log("Address = :" +serverAddress);
        using (var httpClient = new HttpClient())
        {
            var httpResponse = await httpClient.GetAsync(url);
            if (httpResponse.Content != null)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                
                int n = Int32.Parse(responseContent);               
                intToBoolArray(n);

            }
        }

    }


    public void intToBoolArray(int n)
    {

        //Debug.Log("n : " + n);
        int b = 2;
        string binaryForm = Convert.ToString(n, b).PadLeft(16, '0');
        //Debug.Log(binaryForm);
        for (int i = 0; i <= binaryForm.Length -1; i++)
        {
            //Debug.Log(binaryForm[i]);
            if(binaryForm[i] == '0')
            {
                stuffDone[i] = false;
            }
            else
            {
                stuffDone[i] = true;
            }
            //Debug.Log(stuffDone[i]);
            //code block 
            
        }
        GlobalVariables.progressData = stuffDone;
        //Debug.Log("Progress updated to: " + GlobalVariables.progressData[14]);
    } 
   

}
