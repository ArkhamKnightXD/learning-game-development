using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    const float X_MIN_LIMIT = -8.45f;

    const float X_MAX_LIMIT = 147.6f;

    float _lastHorizontalAxis;

    float _lastVerticalAxis;

    Animator _animator;

    float _speedX = 10f;

    Vector3 _deltaPosition;

    Vector3 _characterScale;
    
    GameController gameController;

    Vector3 _heightPosition;

    bool _canJump;


    float horizontalAxis;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        gameController = GameObject.Find("GlobalScriptsText").GetComponent<GameController>();


    }

    void Start()
    {

    }

    
    void Update()
    {

         // Aqui basicamente consigo la distancia a la que se debe mover mi objeto
        _deltaPosition = new Vector3(Input.GetAxis("Horizontal"),0) * _speedX * Time.deltaTime;


        gameObject.transform.Translate(_deltaPosition);

        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, X_MIN_LIMIT, X_MAX_LIMIT),gameObject.transform.position.y,  gameObject.transform.position.z);


//Para poder rotar el personaje
        _characterScale = transform.localScale;

       if (Input.GetAxis("Horizontal") < 0)
        {
            _characterScale.x = -1;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            _characterScale.x = 1;
        }

        //tiene error en esta linea de codigo
        transform.localScale =_characterScale;

        

        // Aqui obtenemos la ultima posicion del horizontal axis y se la mandamos a animator
        if (_lastHorizontalAxis != Input.GetAxis("Horizontal"))
        {
            _lastHorizontalAxis = Input.GetAxis("Horizontal");

            _animator.SetFloat("HorizontalAxis", _lastHorizontalAxis);            
        }

        



        if (_lastVerticalAxis != Input.GetAxis("Vertical"))
        {
            _lastVerticalAxis = Input.GetAxis("Vertical");

            _animator.SetFloat("VerticalAxis", _lastVerticalAxis);            
        }

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

            gameObject.transform.Translate(0, 7 * Time.deltaTime, 0);

        }

        else {

            _canJump = false;


            if (gameObject.transform.position.y > 7) {

                gameObject.transform.Translate(0, 6 * Time.deltaTime, 0);
            }

        }
    }

}
