using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToLoginPage : MonoBehaviour
{
    public void click()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene("Login Screen", LoadSceneMode.Single);
    }
}