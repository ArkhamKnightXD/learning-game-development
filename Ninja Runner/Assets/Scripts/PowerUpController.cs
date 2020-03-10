using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
   
   GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GlobalScriptsText").GetComponent<GameController>();
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other){


       if (other.gameObject.tag.ToString().Contains("Player"))
       {

            Destroy(gameObject);

            gameController.IncrementScore();

            AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.FruitGet);   
       }

        
    }
}
