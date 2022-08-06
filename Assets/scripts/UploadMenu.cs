using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UploadMenu : MonoBehaviour
{
    public playerProgress playerProgress;
    public void Awake()
    {
        playerProgress.requestDataWithGlobalUsername();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("scene_Level_01");
    }
    public void GoHome()
    {
        SceneManager.LoadScene("scene_openingPage");
    }
    public void Reload()
    {
        SceneManager.LoadScene("scene_fileMenu");
    }
    
}
