using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    //PowerUps:
    public GameObject lasrButton;
    public GameObject turtleButton;
    public GameObject spinButton;
    public GameObject meleButton;

    public int Cat_1Score = 0;
    public int Cat_2Score = 0;
    public int Cat_3Score = 0;
    public int Cat_4Score = 0;

    /// <summary>
    /// user progress denoted by 1111 1111 1111 1111
    /// Each one represents a task checked of by admin.
    /// </summary>
    void Awake()
    {
        // PowerUp 1
        if (GlobalVariables.progressData[12])
            Cat_1Score++;
        if (GlobalVariables.progressData[13])
            Cat_1Score++;
        if (GlobalVariables.progressData[14])
            Cat_1Score++;
        if (GlobalVariables.progressData[15])
            Cat_1Score++;

        //PowerUp 2
        if (GlobalVariables.progressData[8])
            Cat_2Score++;
        if (GlobalVariables.progressData[9])
            Cat_2Score++;
        if (GlobalVariables.progressData[10])
            Cat_2Score++;
        if (GlobalVariables.progressData[11])
            Cat_2Score++;

        //PowerUp 3
        if (GlobalVariables.progressData[4])
            Cat_3Score++;
        if (GlobalVariables.progressData[5])
            Cat_3Score++;
        if (GlobalVariables.progressData[6])
            Cat_3Score++;
        if (GlobalVariables.progressData[7])
            Cat_3Score++;
        
        //PowerUp 4
        if (GlobalVariables.progressData[0])
            Cat_4Score++;
        if (GlobalVariables.progressData[1])
            Cat_4Score++;
        if (GlobalVariables.progressData[2])
            Cat_4Score++;
        if (GlobalVariables.progressData[3])
            Cat_4Score++;
        //Enable powerups if 3 or more tasks are complete.
        if (Cat_1Score >= 3)
            lasrButton.SetActive(true);

        if (Cat_2Score >= 3)
            turtleButton.SetActive(true);

        if (Cat_3Score >= 3)
            spinButton.SetActive(true);

        if (Cat_4Score >= 3)
            meleButton.SetActive(true);

        //if (GlobalVariables.progressData[12] || GlobalVariables.progressData[13] || GlobalVariables.progressData[14] || GlobalVariables.progressData[15])
        //{
        //    powerUp_1 = true;
        //    lasrButton.SetActive(true);
        //    Debug.Log("PowerUP 1 is active!");
        //}
        //else
        //{
        //    lasrButton.SetActive(false) ;
        //}
        //if (GlobalVariables.progressData[8] || GlobalVariables.progressData[9] || GlobalVariables.progressData[10] || GlobalVariables.progressData[11])
        //{
        //    turtleButton.SetActive(true);
        //    powerUp_2 = true;
        //    Debug.Log("PowerUP 2 is active!");
        //}
        //else
        //{
        //    turtleButton.SetActive(false);
        //}
        //if (GlobalVariables.progressData[4] || GlobalVariables.progressData[5] || GlobalVariables.progressData[6] || GlobalVariables.progressData[7])
        //{
        //    spinButton.SetActive(true);
        //    powerUp_3 = true;
        //    Debug.Log("PowerUP 3 is active!");
        //}
        //else
        //{
        //    spinButton.SetActive(false);
        //}
        //if (GlobalVariables.progressData[0] || GlobalVariables.progressData[1] || GlobalVariables.progressData[2] || GlobalVariables.progressData[3])
        //{
        //    powerUp_4 = true;
        //    Debug.Log("PowerUP 4 is active!");
        //}


    }

    
}
