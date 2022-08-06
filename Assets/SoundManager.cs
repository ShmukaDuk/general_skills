using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHitSound, omNomSound, zapSound, jumpSound, hitSound, tnmtSound; //, fireSound, jumpSound, enemyDeathSound;
    static AudioSource audioSrc;

    private void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("playerHit");
        zapSound = Resources.Load<AudioClip>("zap");
        jumpSound = Resources.Load<AudioClip>("jump");
        hitSound = Resources.Load<AudioClip>("hit");
        tnmtSound = Resources.Load<AudioClip>("tnmt");
        omNomSound = Resources.Load<AudioClip>("omNom");
        audioSrc = GetComponent<AudioSource>();

    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "playerHit":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "zap":
                audioSrc.PlayOneShot(zapSound);
                break;
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "hit":
                audioSrc.PlayOneShot(hitSound);
                break;
            case "tnmt":
                audioSrc.PlayOneShot(tnmtSound);
                break;
            case "omNom":
                audioSrc.PlayOneShot(omNomSound);
                break;

        }
    }

}
