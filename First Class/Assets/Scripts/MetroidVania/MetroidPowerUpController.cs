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
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerSlider" || other.gameObject.tag == "PlayerAttack" || other.gameObject.tag == "PlayerHighJump")
        {
            gameController.IncrementScore();

            Destroy(gameObject);

            other.gameObject.tag = "PlayerSlider";

            AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.Item);
        }

    }
}
