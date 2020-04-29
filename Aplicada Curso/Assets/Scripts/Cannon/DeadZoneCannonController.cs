using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneCannonController : MonoBehaviour
{
    public GameCannonController gameController;


    void Start()
    {
        gameController = GameObject.Find("GlobalScriptsText").GetComponent<GameCannonController>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            gameController.DecrementLives();

            AudioManagerCannon.Instance.PlaySoundEffect(AudioManagerCannon.SoundEffect.Explode);
        }

        Destroy(other.gameObject);

    }
}
