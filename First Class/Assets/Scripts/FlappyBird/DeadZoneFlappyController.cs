using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneFlappyController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameFlappyController gameController;

    void Awake()
    {
        // Esto busca en unity un objeto con el nombre de GlobalScriptsText y cuando lo encuentre nos retorna el objeto

        gameController = GameObject.Find("GlobalScriptsText").GetComponent<GameFlappyController>();
    }

    void OnTriggerEnter(Collider other)
    {
      
            gameController.GameOverByFall();

            AudioManagerFlappy.Instance.PlaySoundEffect(AudioManagerFlappy.SoundEffect.GameOver);  

    }
}
