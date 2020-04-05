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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //gameController.DecrementLives();

            AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.Explode);      
        } 
        
    }
}
