using UnityEngine;
using System.Net.Http;
using UnityEngine.UI;

public class getHighScore : MonoBehaviour
{
    public Text highScore1;
    public Text highScore2;
    public Text highScore3;
    public Text highScore4;
    public Text highScore5;



    public string score1;
    
    static string username = GlobalVariables.Username;
   public void getHighScores()
    {        
        GetRequest(GlobalVariables.serverAddress + "/highScore5");        
    }
    public void StoreScores(string jsonString)
    {
        
        //Debug.Log("{\"users\":" + jsonString + "}");
        UserObject player = JsonUtility.FromJson<UserObject>("{\"users\":" + jsonString + "}");
        //Debug.Log(player.users[0].ToString());
        highScore1.text = player.users[0].highScore + " - " + player.users[0].username;
        highScore2.text = player.users[1].highScore + " - " + player.users[1].username;
        highScore3.text = player.users[2].highScore + " - " + player.users[2].username;
        highScore4.text = player.users[3].highScore + " - " + player.users[3].username;
        highScore5.text = player.users[4].highScore + " - " + player.users[4].username;




    }

    async private void GetRequest(string url)
    {
        
        using (var httpClient = new HttpClient())
        {
            var httpResponse = await httpClient.GetAsync(url);
            if (httpResponse.Content != null)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                string json = responseContent;
                StoreScores(responseContent);
                
            }
        }

    }
   


}
