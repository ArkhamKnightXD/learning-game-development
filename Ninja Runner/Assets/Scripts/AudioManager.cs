using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource GameSong;

    public AudioSource DamageTaken;

    public AudioSource FruitGet;

    public AudioSource PlayerJump;

    public AudioSource GameOver;

    public AudioSource Win;

    private void Awake()
    {
        Instance = this;
    }
    
    public enum SoundEffect
    {
        GameSong,
        DamageTaken,
        FruitGet,
        PlayerJump,
        Win,
        GameOver
    }

    public void PlaySoundEffect(SoundEffect type)
    {
        switch (type)
        {
        case SoundEffect.GameSong:
            GameSong.Play();
            break;

        case SoundEffect.DamageTaken:
            DamageTaken.Play();
            break;

        case SoundEffect.FruitGet:
            FruitGet.Play();
            break;

        case SoundEffect.PlayerJump:
            PlayerJump.Play();
            break;

        case SoundEffect.Win:
            GameSong.Stop();
            Win.Play();
            break;

        case SoundEffect.GameOver:
            GameSong.Stop();
            GameOver.Play();
            break;
            
        }
    }
}
