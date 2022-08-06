using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToLandingPage : MonoBehaviour
{
    void Start()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene("LandingPageScene", LoadSceneMode.Single);
    }
}

