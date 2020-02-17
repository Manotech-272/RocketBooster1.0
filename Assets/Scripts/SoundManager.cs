using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip soundWin;

    public AudioClip soundDeathSound;

    public AudioClip soundLoadScene;

    public AudioClip soundReachedLandingPad;

    public AudioClip soundImpact;

    public AudioClip soundThruster;

    public AudioClip soundBackground;

    public static SoundManager instance;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
