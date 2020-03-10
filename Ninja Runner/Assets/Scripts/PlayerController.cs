using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    const float X_MIN_LIMIT = -8.45f;

    const float X_MAX_LIMIT = 10.22f;

    float _lastHorizontalAxis;

    float _lastVerticalAxis;

    Animator _animator;

    float _speedX = 10f;

    float _speedY = 25f;

    Vector3 _deltaPosition;
    
    GameController gameController;

    Vector3 _heightPosition;

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

        // translate es como un += para la posicion.
        gameObject.transform.Translate(_deltaPosition);

        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, X_MIN_LIMIT, X_MAX_LIMIT),gameObject.transform.position.y,  gameObject.transform.position.z);



        // Aqui obtenemos la ultima posicion del horizontal axis y se la mandamos a animator
        if (_lastHorizontalAxis != Input.GetAxis("Horizontal"))
        {
            _lastHorizontalAxis = Input.GetAxis("Horizontal");

            _animator.SetFloat("HorizontalAxis", _lastHorizontalAxis);            
        }

        


        _heightPosition = new Vector3(0,Input.GetAxis("Vertical")) * _speedY * Time.deltaTime;

        // translate es como un += para la posicion.
        gameObject.transform.Translate(_heightPosition);


        if (_lastVerticalAxis != Input.GetAxis("Vertical"))
        {
            _lastVerticalAxis = Input.GetAxis("Vertical");

            _animator.SetFloat("VerticalAxis", _lastVerticalAxis);            
        }

    }


}
