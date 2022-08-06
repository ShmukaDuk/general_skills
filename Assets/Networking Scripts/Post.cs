using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class Post : MonoBehaviour
{
    //Get data from Unity
    public Text usernameText;
    public Text passwordText;
    public Text newPassword;
    public Text newPassword2;
    public string authToken;


    //Ip of API
    public string address = "localhost";

    //Check if password enter'd two times correctly.
    public bool checkNewPass(Text newPassword, Text newPassword2)
    {
        if (newPassword.text == newPassword2.text)
        {
            
            return true;
        }
        else
        {
            
            return false;
        }
        
    }
    //Post Send button is clicked
    public void clicked()
    {
        if (checkNewPass(newPassword, newPassword2) == true)
        {
            Debug.Log("Sending payload");
            var stringPayload = "{\"username\":\"" + usernameText.text + "\"," +
                            "\"password\":\"" + passwordText.text + "\"," +
                            "\"newPassword\":\"" + newPassword.text + "\"}";
            PostRequest("http://192.168.1.103:8080/main/user/update", stringPayload);
        }
        else
        {
            Debug.Log("fat fingers!");
        }
        
    }

    async static void PostRequest(string url, string stringPayload)
    {
        var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
        //start new client 
        using (var httpClient = new HttpClient())
        {
            // Do the actual request and await the response
            var httpResponse = await httpClient.PostAsync(url, httpContent);
            // If the response contains content we want to read it!
            if (httpResponse.Content != null)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                // From here on you could deserialize the ResponseContent back again to a concrete C# type using Json.Net
                string json = responseContent;
                Debug.Log(responseContent);
                


            }
        }

    }
}
