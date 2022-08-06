using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
   public void uploadScene()
    {
        SceneManager.LoadScene("scene_FileMenu");
    }
    public void playOnline()
    {

        SceneManager.LoadScene("scene_Level_01", LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
