using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZoneController : MonoBehaviour
{
    public MetroidGameController GameController;


    void Start()
    {
        GameController = GameObject.Find("GlobalScriptsText").GetComponent<MetroidGameController>();
        
    }


    
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "PlayerAntiAcid" && other.gameObject.tag != "PlayerExplosion" && gameObject.tag == "Acid")
        {
            GameController.DecrementLives();

            AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.Damage);      
        } 
        

        if (gameObject.tag == "Spike")
        {
            GameController.DecrementLives();

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
