using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroidPowerUpController : MonoBehaviour
{
    public MetroidGameController GameController;


    void Start()
    {
        GameController = GameObject.Find("GlobalScriptsText").GetComponent<MetroidGameController>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag == "SliderPowerUp")
        {
            GameController.IncrementScore();

            Destroy(gameObject);

            AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.PowerUp);

            other.gameObject.tag = "PlayerSlider";    
        }


        if (other.gameObject.tag == "PlayerSlider" && gameObject.tag == "HighJumpPowerUp")
        {
            GameController.IncrementScore();

            Destroy(gameObject);

            AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.PowerUp);

            other.gameObject.tag = "PlayerHighJump";    
        }


        if (other.gameObject.tag == "PlayerHighJump" && gameObject.tag == "AntiAcidPowerUp")
        {
            GameController.IncrementScore();

            Destroy(gameObject);

            AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.PowerUp);

            other.gameObject.tag = "PlayerAntiAcid";    
        }


        if (other.gameObject.tag == "PlayerAntiAcid" && gameObject.tag == "Explosion")
        {
            GameController.IncrementScore();

            Destroy(gameObject);

            AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.PowerUp);

            AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.Timer);

            other.gameObject.tag = "PlayerExplosion";    
        }

        if (other.gameObject.tag == "PlayerExplosion" && gameObject.tag == "FinalJelly")
        {
            GameController.IncrementScore();

            Destroy(gameObject);

            AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.PowerUp);

            other.gameObject.tag = "Finish";    
        }


        if (gameObject.tag == "Coin")
        {
            GameController.IncrementScore();

            Destroy(gameObject);

            AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.Item);

        }

    }
}
