using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToOfflineMode1 : MonoBehaviour
{
   public void offlineButton()
    {
        SceneManager.LoadScene("scene_camera", LoadSceneMode.Single);
        GlobalVariables.online = false;
        Screen.autorotateToPortrait = false;
    }
}
