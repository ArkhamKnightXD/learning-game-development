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
        Destroy(other.gameObject);

        AudioManagerCannon.Instance.PlaySoundEffect(AudioManagerCannon.SoundEffect.Explode);
    }
}
