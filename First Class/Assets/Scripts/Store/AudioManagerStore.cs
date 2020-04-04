﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerStore : MonoBehaviour
{
    public static AudioManagerStore Instance;

    public AudioSource Song;

    public AudioSource GameOver;

    public AudioSource Win;


    private void Awake()
    {
        Instance = this;
    }
    
    public enum SoundEffect
    {
        Song,
        GameOver,
        Win
    }
    

    public void PlaySoundEffect(SoundEffect type)
    {
        switch (type)
        {

        case SoundEffect.Song:
            Song.Play();
            break;

        case SoundEffect.GameOver:
            Song.Stop();
            GameOver.Play();
            break;

        case SoundEffect.Win:
            Song.Stop();
            Win.Play();
            break;

        }
    }
}
