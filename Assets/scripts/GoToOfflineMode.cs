using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToOfflineMode : MonoBehaviour
{
   public void offlineButton()
    {
        SceneManager.LoadScene("scene_outSide", LoadSceneMode.Single);
        GlobalVariables.online = false;
        Screen.autorotateToPortrait = false;
    }
}
