using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource BallExplosion;

    public AudioSource BallCapture;

    public AudioSource Song;

    public AudioSource GameOver;

    public AudioSource Win;


    private void Awake()
    {
        Instance = this;
    }

    
    public enum SoundEffect
    {
        Explode,
        Capture,
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

        case SoundEffect.Capture:
            BallCapture.Play();
            break;

        case SoundEffect.Explode:
            BallExplosion.Play();
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
