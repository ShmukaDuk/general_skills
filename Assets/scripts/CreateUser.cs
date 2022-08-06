using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class CreateUser : MonoBehaviour

{
    public Text usernameText;
    public Text passwordText;
    public Text passwordText1;
    public string responseContent;
    public GameObject userExistsButton;
    public GameObject userCreatedButton;




    public void createUserSend()
    {
        if (passwordText.text.Equals(passwordText1.text))
        {
            var stringPayload = "{\"username\":\"" + usernameText.text + "\"," +
                        "\"password\":\"" + passwordText.text + "\"}";
            PostRequest(GlobalVariables.serverAddress + "user/createUser2", stringPayload);
        }
        else
        {
            Debug.Log("password missmatch");
            Debug.Log(passwordText.text + passwordText1.text);
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
            if (httpResponse.Content != null)
            {

                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                // From here on you could deserialize the ResponseContent back again to a concrete C# type using Json.Net
                string json = responseContent;
                Debug.Log(responseContent);
                if (json.Equals("user exists"))
                {
                    userExistsButton.SetActive(true);
                }
                if (json.Equals("user created"))
                {
                    userCreatedButton.SetActive(true);
                }


            }

        }
    }
}
