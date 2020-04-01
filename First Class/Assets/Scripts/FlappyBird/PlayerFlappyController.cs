using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlappyController : MonoBehaviour
{

    const float X_MIN_LIMIT = -8.45f;

    const float X_MAX_LIMIT = 147.6f;

    float _lastHorizontalAxis;

    float _lastVerticalAxis;

    Vector3 _currentSpeed;

    Vector3 _deltaPosition;

    GameFlappyController gameController;


    bool _canJump;

   
    private void Awake()
    {
        gameController = GameObject.Find("GlobalScriptsText").GetComponent<GameFlappyController>();

    }



    
    void Update()
    {

         // Aqui basicamente consigo la distancia a la que se debe mover mi objeto
      //  _deltaPosition = new Vector3(Input.GetAxis("Horizontal"),0) * _speedX * Time.deltaTime;


       // gameObject.transform.Translate(_deltaPosition);

      //  gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, X_MIN_LIMIT, X_MAX_LIMIT),gameObject.transform.position.y,  gameObject.transform.position.z);

        gameObject.transform.Translate(_currentSpeed * Time.deltaTime + Physics.gravity * Mathf.Pow(Time.deltaTime, 2)/ 2);

        _currentSpeed += Physics.gravity * Time.deltaTime;

    

       /* if (_lastVerticalAxis != Input.GetAxis("Vertical"))
        {
            _lastVerticalAxis = Input.GetAxis("Vertical");

            _animator.SetFloat("VerticalAxis", _lastVerticalAxis);            
        }*/

        
        ManageJump();

    }


     // Funcion para hacer saltar al personaje 

     void ManageJump()
     {


        if (gameObject.transform.position.y < 5) {

            _canJump = true;
        }


        if (Input.GetKey("up") && _canJump && gameObject.transform.position.y < 5)
        {
            AudioManagerFlappy.Instance.PlaySoundEffect(AudioManagerFlappy.SoundEffect.PlayerJump);
            gameObject.transform.Translate(0, 7 * Time.deltaTime, 0);

            gameController.IncrementScore();

        }

    }

   

}
