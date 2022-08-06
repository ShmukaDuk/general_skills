using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnMute : MonoBehaviour
{
    public void UnMuteAllSound()
    {
        Debug.Log("Setting audio to 1");
        AudioListener.volume = 1;
    }
}
