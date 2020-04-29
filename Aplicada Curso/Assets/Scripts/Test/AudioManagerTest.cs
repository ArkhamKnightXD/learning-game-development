using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerTest : MonoBehaviour
{
    public static AudioManagerTest Instance;

    public AudioSource CubePoint;

    public AudioSource CubeDamage;

    public AudioSource CubeExtraLive;

    public AudioSource Song;

    public AudioSource GameOver;

    public AudioSource Win;

    private void Awake()
    {
        Instance = this;
    }
    
    public enum SoundEffect
    {
        Point,

        Damage,

        Song,

        GameOver,

        ExtraLive,

        Win
    }

    public void PlaySoundEffect(SoundEffect type)
    {
        switch (type)
        {
        case SoundEffect.Point:
            CubePoint.Play();
            break;

        case SoundEffect.Damage:
            CubeDamage.Play();
            break;

        case SoundEffect.ExtraLive:
            CubeExtraLive.Play();
            break;

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
