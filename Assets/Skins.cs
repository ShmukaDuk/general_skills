using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;

public class Skins : MonoBehaviour
{
    public GameObject Crown_Gold;
    public GameObject Crown_Silver;
    public GameObject Crown_Bronze;

    
    public void Awake()
    {
        
        GetRequest(GlobalVariables.serverAddress + "/highScore5");
       
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
                GetRank(responseContent);

            }
        }

    }
    public void GetRank(string jsonString)
    {        
        UserObject player = JsonUtility.FromJson<UserObject>("{\"users\":" + jsonString + "}");
        if (GlobalVariables.username == player.users[0].username)
            GlobalVariables.ranking = 1;
        if (GlobalVariables.username == player.users[1].username)
            GlobalVariables.ranking = 2;
        if (GlobalVariables.username == player.users[2].username)
            GlobalVariables.ranking = 3;
        Debug.Log("My rank is: " + GlobalVariables.ranking);
        if (GlobalVariables.ranking == 1)
        {
            Crown_Gold.SetActive(true);
        }
            
        if (GlobalVariables.ranking == 2)
            Crown_Silver.SetActive(true);
        if (GlobalVariables.ranking == 3)
            Crown_Bronze.SetActive(true);
    }





}
