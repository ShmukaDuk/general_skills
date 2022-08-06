using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartGame : MonoBehaviour
{


    // Start is called before the first frame update

    public void restartGame()
    {
        GlobalVariables.isFightingBoss = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("scene_Level_01", LoadSceneMode.Single);
    }

}