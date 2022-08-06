using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    
    public Text myScore;
    public GameObject PauseButton;

    private string myScoreString;
    // Start is called before the first frame update
    void Start()
    {        
        myScore.text = GlobalVariables.currentScore.ToString();
        PauseButton.SetActive(false);
        
    }

    // Update is called once per frame

}
