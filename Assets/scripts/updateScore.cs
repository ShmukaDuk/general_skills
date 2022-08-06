using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class updateScore : MonoBehaviour
{
    public getHighScore myHighScore;


    public static string serverAddress = GlobalVariables.serverAddress + "user/submit";    
    public void UpdateScore()
    {
        Debug.Log(GlobalVariables.Username + "Global UserName");
        var stringPayload = "{\"username\":\"" + GlobalVariables.Username + "\"," +
                            "\"highScoreName\":\"" + "ASS" + "\"," +
                           "\"highScore\":\"" + GlobalVariables.currentScore.ToString() + "\"}";
        PostRequest(serverAddress, stringPayload);
        myHighScore.getHighScores();
       


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
