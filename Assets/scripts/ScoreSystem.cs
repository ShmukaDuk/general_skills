using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{   
    public updateScore updateScore;
    public GameObject leaderboard;
    public Clock clock;
    


    public void EndGame()
    {
        GlobalVariables.currentScore = clock.time;
        updateScore.UpdateScore();
        leaderboard.SetActive(true);
            

    }
    public void Update()
    {
        if(GlobalVariables.levelComplete)
        {
            EndGame();
            GlobalVariables.levelComplete = false;
        }
    }

}
