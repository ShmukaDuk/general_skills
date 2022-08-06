using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LogIn : MonoBehaviour

{
    public InputField inputField1;
    public InputField inputField2;

    public Toggle rememberPassword;
    public playerProgress playerProgress;
   
    public GameObject responsePopup;
    public Text responseForUser;

    public Text usernameText;
    public Text passwordText;
    
    public Text token;
    public string responseContent;

    public GameObject thisobject;
    public GameObject nextObject;

    public Text PlaceHolederUsername;
    public Text PlaceHolederPass;

    string storedUsername;
    string storedPass;
    public void Awake()
    {
        StartCoroutine("GetUser");
        StartCoroutine("GetPass");


    }



    public void logInSend()
    {
        if(rememberPassword.isOn)
        {
            
            WriteUser(inputField1.text.ToString());
            WritePass(inputField2.text.ToString());

        }

        var stringPayload = "{\"username\":\"" + inputField1.text.ToString() + "\"," +
                        "\"password\":\"" + inputField2.text.ToString() + "\"}";
        Debug.Log("sending post request to: " + GlobalVariables.serverAddress + "user/logIn" + stringPayload);
        PostRequest(GlobalVariables.serverAddress + "user/logIn", stringPayload);

    }

    async private void PostRequest(string url, string stringPayload)
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
                //Debug.Log(responseContent);

                string wrongPassResponse = "Password incorrect cannot login";

                //string userToken = newToken.getToken();
                //token.text = responseContent;
                if (responseContent != "user does not exist" && responseContent != wrongPassResponse)
                {
                    GlobalVariables.authToken = responseContent;                   
                    GlobalVariables.online = true;
                    GlobalVariables.username = inputField1.text;

                    Debug.Log("recieved key: " + GlobalVariables.authToken + " from key generation function for user: " + GlobalVariables.username);
                    nextObject.SetActive(true);
                    thisobject.SetActive(false);
                    string temp = GlobalVariables.username;
                    GlobalVariables.username = temp;
                    playerProgress.RequestData(temp);
                    //Debug.Log("global Username: " +GlobalVariables.username);
                }
                else
                {
                    responsePopup.SetActive(true);
                    responseForUser.text = responseContent;
                    Debug.Log(responseContent);
                }



            }
        }

    }


    public static void WriteUser(string text)
    {
        string path = Application.persistentDataPath + "/user.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);
        //StreamWriter writer2 = new StreamWriter()
        writer.WriteLine(text);
        writer.Close();
        StreamReader reader = new StreamReader(path);
        Debug.Log("saving user as: " + reader.ReadToEnd());
        reader.Close();
    }
    public static void WritePass(string text)
    {
        string path = Application.persistentDataPath + "/pass.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);
        //StreamWriter writer2 = new StreamWriter()
        writer.WriteLine(text);
        writer.Close();
        StreamReader reader = new StreamReader(path);
        Debug.Log("saving password as: "+reader.ReadToEnd());
        reader.Close();
    }
    IEnumerator GetUser()
    {
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
            StreamReader reader = new StreamReader(Application.persistentDataPath + "/user.txt");
            if (reader != null)
            {
                string temp = "";
                temp = reader.ReadToEnd().ToLower().ToString();
                inputField1.text = temp.Replace("\n", "").Replace("\r", "");
                reader.Close();

            }
            yield return null;
        }
    }
    IEnumerator GetPass()
    {
        StreamReader reader2 = new StreamReader(Application.persistentDataPath + "/pass.txt");
        if (reader2 != null)
        {
            string temp2 = "";
            temp2 = reader2.ReadToEnd().ToLower().ToString();
            inputField2.text = temp2.Replace("\n", "").Replace("\r", "");

            reader2.Close();
            yield return null;
        }
    }
}
