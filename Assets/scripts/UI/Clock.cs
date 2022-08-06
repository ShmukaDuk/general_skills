using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Clock : MonoBehaviour
{
    public float time = 0f;
    
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        txt.text = "skeet";
    }
    private void Update()
    {
        if (!GlobalVariables.levelComplete)
        {

            time += Time.deltaTime; 
            //reound to 2dp
            time = (float)System.Math.Round(time * 100f) / 100f;
            time.ToString(); 
            //Convert raw seconds to a displayed string
            TimeSpan t = TimeSpan.FromSeconds(time);
            string answer = string.Format("{0:D2}m:{1:D2}s:{2:D1}ms",                            
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);
            txt.text = answer;
           
        }
        
    }
    public void eatPasta()
    {
        time += -2f;
    }
}
