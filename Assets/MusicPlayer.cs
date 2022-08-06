using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clips;


    

    // Use this for initialization
    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        audioSource.loop = false;
        CallAudio();
    }
    private AudioClip GetRandomClip()
    {
        return clips[Random.Range(0, clips.Length)];
    }

    void CallAudio()
    {
        Invoke("RandomSoundness", 10);
    }

    private void Update()
    {        
        
            if (!audioSource.isPlaying)
            {
                audioSource.clip = GetRandomClip();
                audioSource.Play();
            }
        
        
        
       

        
    }
}

