using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameisPaused = false;

    public void resume()
    {
        Time.timeScale = 1f;
    }
    public void pause()
    {
        Time.timeScale = 0f;
        GameisPaused = true;
    }
    public void loginScreen()
    {
        GlobalVariables.isFightingBoss = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("scene_openingPage", LoadSceneMode.Single);

    }
}
