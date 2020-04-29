using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerMetroid : MonoBehaviour
{
    public static AudioManagerMetroid Instance;

    public AudioSource Song;

    public AudioSource Jump;

    public AudioSource Damage;

    public AudioSource Attack;

    public AudioSource Shoot;

    public AudioSource Item;

    public AudioSource GameOver;

    public AudioSource Win;


    private void Awake()
    {
        Instance = this;
    }
    
    public enum SoundEffect
    {
        Song,

        Jump,

        Damage,

        Attack,

        Shoot,

        Item,

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
            
        case SoundEffect.Jump:
            Jump.Play();
            break;

        case SoundEffect.Damage:
            Damage.Play();
            break;

        case SoundEffect.Attack:
            Attack.Play();
            break;

        case SoundEffect.Shoot:
            Shoot.Play();
            break;

        case SoundEffect.Item:
            Item.Play();
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
