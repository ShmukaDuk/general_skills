using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;

public class SetGlobalIP : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
       
        SetIPLAN(GlobalVariables.serverAddress + "ipCheck");
        SetIPOnline(GlobalVariables.serverAddressOline + "ipCheck");        

    }
    async private void SetIPLAN(string url)
    {

        using (var httpClient = new HttpClient())
        {
            
            var httpResponse = await httpClient.GetAsync(url);
            if (httpResponse.Content != null)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                string json = responseContent;
                Debug.Log("Lan IP address configured");
                

            }           
        }

    }
    async private void SetIPOnline(string url)
    {
        using (var httpClient = new HttpClient())
        {
            
            var httpResponse = await httpClient.GetAsync(url);
            if (httpResponse.Content != null)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                string json = responseContent;
                Debug.Log("Online IP address configured");
                GlobalVariables.serverAddress = GlobalVariables.serverAddressOline;

            }           
        }
    }
}
