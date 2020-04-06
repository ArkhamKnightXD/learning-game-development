using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZoneController : MonoBehaviour
{
    public MetroidGameController gameController;


    void Start()
    {
        gameController = GameObject.Find("GlobalScriptsText").GetComponent<MetroidGameController>();
    }


    // Cambiar esto por ontringerstay y ver que otros cambios mas hacer
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "PlayerAntiAcid")
        {
            gameController.DecrementLives();

            AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.Damage);      
        } 
        

        if (gameObject.name == "Spike")
        {
            gameController.DecrementLives();

            AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.Damage);
        }

    }
}
