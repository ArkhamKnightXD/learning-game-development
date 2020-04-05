using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroidPlayerController : MonoBehaviour
{
    
    Vector3 _movementSpeed = new Vector3(5, 5), _runningSpeed= new Vector3(15, 15);
    Rigidbody _rigidbody;
    Animator _animator;
    SpriteRenderer _renderer;
    Vector3 _newPosition = new Vector3();
    GameObject _player;

   
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        Physics.IgnoreLayerCollision(8, 10);
        
        _player = GameObject.FindGameObjectWithTag("Player");

    }


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
       
        _newPosition.x = Input.GetAxis("Horizontal")* (Input.GetButton("Fire3") ? _runningSpeed.x : _movementSpeed.x);

        //_newPosition.y = Input.GetAxis("Vertical")* (Input.GetButton("Fire3") ? _runningSpeed.y : _movementSpeed.y);

        _animator.SetFloat("Speed",_newPosition.magnitude);
       
         _rigidbody.MovePosition(transform.position + _newPosition* Time.deltaTime);

         _animator.SetBool("Attack", Input.GetButton("Fire1"));

        _renderer.flipX=_newPosition.x < 0;

       
    }
}
