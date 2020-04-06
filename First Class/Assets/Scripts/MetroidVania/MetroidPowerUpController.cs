using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroidPowerUpController : MonoBehaviour
{
    public MetroidGameController gameController;


    void Start()
    {
        gameController = GameObject.Find("GlobalScriptsText").GetComponent<MetroidGameController>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag == "SliderPowerUp")
        {
            gameController.IncrementScore();

            Destroy(gameObject);

            AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.Item);

            other.gameObject.tag = "PlayerSlider";    
        }


        if (other.gameObject.tag == "PlayerSlider" && gameObject.tag == "HighJumpPowerUp")
        {
            gameController.IncrementScore();

            Destroy(gameObject);

            AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.Item);

            other.gameObject.tag = "PlayerHighJump";    
        }


        if (other.gameObject.tag == "PlayerHighJump" && gameObject.tag == "AntiAcidPowerUp")
        {
            gameController.IncrementScore();

            Destroy(gameObject);

            AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.Item);

            other.gameObject.tag = "PlayerAntiAcid";    
        }

    }
}
