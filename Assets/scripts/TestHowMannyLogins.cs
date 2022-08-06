using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestHowMannyLogins : MonoBehaviour
{

    public Text usernameText;
    public Text passwordText;
    public static string serverAddress = GlobalVariables.serverAddress + "createUser2";
    public string responseContent;

    public int tempUser = 0;
    public string skeet = "";


    public void logInSend()
    {
        bool go = true;
        int i = 0;
        while(go) {
            i++;
            string username = i.ToString();
            //Make user here
            var stringPayload = "{\"username\":\"" + username + "\"," +
                        "\"password\":\"" + passwordText.text + "\"}";
            PostRequest(serverAddress, stringPayload);
            Debug.Log(i + "user created");
            System.Threading.Thread.Sleep(50);
            if (i == 100000)
                go = false;
        }
        
    }

    async private void PostRequest(string url, string stringPayload)
    {
        var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
        //start new client 
        using (var httpClient = new HttpClient())
        {
            // Do the actual request and await the response
            var httpResponse = await httpClient.PostAsync(url, httpContent);

        }

    }
}
