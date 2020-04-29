using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameCannonController gameController;


    void Start()
    {
        gameController = GameObject.Find("GlobalScriptsText").GetComponent<GameCannonController>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag ==  "Bullet")
        {
            Destroy(gameObject);

            gameController.IncrementScore();

            AudioManagerCannon.Instance.PlaySoundEffect(AudioManagerCannon.SoundEffect.Explode);
        }
       
    }
}
