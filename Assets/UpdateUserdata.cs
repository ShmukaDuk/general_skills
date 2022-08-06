using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UnityEngine;

public class UpdateUserdata : MonoBehaviour
{    
    public void updateData2(int cat, int subCat)
    {
        Debug.Log(GlobalVariables.Username + "Global UserName");        
        GetRequest(GlobalVariables.serverAddress + "/admin/updateData2/" + GlobalVariables.username +"/" + cat + "/" + subCat);
        //myHighScore.getHighScores();



    }
    async private void GetRequest(string url)
    {
        //var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
        using (var httpClient = new HttpClient())
        {
            var httpResponse = await httpClient.GetAsync(url);
            if (httpResponse.Content != null)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                string json = responseContent;
                Debug.Log(responseContent);
            }
        }

    }
}
