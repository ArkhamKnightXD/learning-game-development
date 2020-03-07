using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float _speedX = 10f;

    Vector3 deltaPosition;
    
    GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GlobalScriptsText").GetComponent<GameController>();
    }

    
    void Update()
    {
         // Aqui basicamente consigo la distancia a la que se debe mover mi objeto
        deltaPosition = new Vector3(Input.GetAxis("Horizontal"),0) * _speedX * Time.deltaTime;

        // translate es como un += para la posicion.
        gameObject.transform.Translate(deltaPosition);
    }


    private void OnTriggerEnter(Collider other){

       // gameController.IncrementScore();

        Destroy(other.gameObject);

        AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.CoinGet);
    }
}
