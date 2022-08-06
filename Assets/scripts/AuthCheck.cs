using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AuthCheck : MonoBehaviour
{
    public static string serverAddress = GlobalVariables.serverAddress + "authCheck";
    string username = GlobalVariables.Username;
    public void TokenCheck()
    {
        var stringPayload = "{\"username\":\"" + username + "\"," +
                           "\"token\":\"" + GlobalVariables.authToken + "\"}";
        PostRequest(serverAddress, stringPayload);

    }
    

    async private void PostRequest(string url, string stringPayload)
    {
        var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
        using (var httpClient = new HttpClient())
        {            
            var httpResponse = await httpClient.PostAsync(url, httpContent);           
            if (httpResponse.Content != null)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();                
                string json = responseContent;
                Debug.Log(responseContent);
            }
        }

    }
}
