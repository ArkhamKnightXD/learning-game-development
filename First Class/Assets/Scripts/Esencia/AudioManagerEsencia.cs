﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerEsencia : MonoBehaviour
{
    public static AudioManagerEsencia Instance;

    public AudioSource EnemyExplosion;

    public AudioSource CubeCapture;

    public AudioSource Song;

    public AudioSource GameOver;


    private void Awake()
    {
        Instance = this;
    }


    public enum SoundEffect
    {
        Explosion,
        Capture,
        Song,
        GameOver
    }


    public void PlaySoundEffect(SoundEffect type)
    {
        switch (type)
        {
        case SoundEffect.Song:
            Song.Play();
            break;

        case SoundEffect.Capture:
            CubeCapture.Play();
            break;

        case SoundEffect.Explosion:
            EnemyExplosion.Play();
            break;

        case SoundEffect.GameOver:
            Song.Stop();
            GameOver.Play();
            break;            
        }
    }
}
