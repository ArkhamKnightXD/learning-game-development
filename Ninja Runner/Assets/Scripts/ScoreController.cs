using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GlobalScriptsText").GetComponent<GameController>();
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

       if (other.gameObject.tag.ToString().Contains("Player"))
       {

            Destroy(gameObject);

            gameController.IncrementScore();

            AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.FruitGet);   
       }
        
    }
}
