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


    
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "PlayerAntiAcid" && other.gameObject.tag != "PlayerExplosion" && gameObject.tag == "Acid")
        {
            gameController.DecrementLives();

            AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.Damage);      
        } 
        

        if (gameObject.tag == "Spike")
        {
            gameController.DecrementLives();

            AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.Damage);
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerAntiAcid" && gameObject.tag == "FakeFloor")
        {
            Destroy(gameObject);
            AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.Item);      
        }
    }
}
