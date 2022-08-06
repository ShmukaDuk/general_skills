using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{ 
    
    
    
        public void MuteAllSound()
        {
        Debug.Log("Setting audio to 0");
        AudioListener.volume = 0;
        }

    
}
