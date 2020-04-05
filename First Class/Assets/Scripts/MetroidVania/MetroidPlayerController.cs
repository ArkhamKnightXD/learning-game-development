using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroidPlayerController : MonoBehaviour
{
    
    Vector3 _movementSpeed = new Vector3(8, 8), _runningSpeed= new Vector3(15, 15);
    Rigidbody _rigidbody;
    Animator _animator;
    SpriteRenderer _renderer;
    Vector3 _newPosition = new Vector3();
    GameObject _player;

    bool _sliding = false;

    float _sliderTime = 0f;

    float _maxSliderTime = 1.5f;

    bool jumping = false;


    float jumpTime;
    
    float maxJumpingTime = 1.5f;

   
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
       // Physics.IgnoreLayerCollision(8, 10);
        
        _player = GameObject.FindGameObjectWithTag("Player");

    }


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {

        Jump();

        
        _newPosition.x = Input.GetAxis("Horizontal") * (Input.GetButton("Fire2") ? _runningSpeed.x : _movementSpeed.x);

        _renderer.flipX=_newPosition.x < 0;

        //_newPosition.y = Input.GetAxis("Vertical")* (Input.GetButton("Fire3") ? _runningSpeed.y : _movementSpeed.y);

        _animator.SetFloat("Speed",_newPosition.magnitude);
       
         _rigidbody.MovePosition(transform.position + _newPosition* Time.deltaTime);


         


        if (_player.gameObject.tag == "PlayerSlider")
        {
            Slide();    
        }
        

        if (_player.gameObject.tag == "PlayerAttack")
        {
            Slide();
            HighJump();    
        }


        if (_player.gameObject.tag == "PlayerAttack")
        {
            Slide();

            _animator.SetBool("Attack", Input.GetButton("Fire1"));    
        }
       
    }


    private void Jump()
    {
        if (Input.GetButton("Jump") && !jumping)
        {
            jumpTime = 0f;

            _rigidbody.AddForce(transform.up * 390f);
            _animator.SetBool("Jump", true);

            jumping = true;
        }

        if (jumping)
        {
            jumpTime += Time.deltaTime;

            if (jumpTime > maxJumpingTime)
            {
                jumping = false;

                _animator.SetBool("Jump", false);

            }   
        }
        
    }


    private void HighJump()
    {
        
    }


    private void Slide()
    {
        if (Input.GetButton("Fire3") && !_sliding)
        {
            _sliderTime =0f;

            gameObject.GetComponent<BoxCollider>().enabled = false;
            _animator.SetBool("Slide", true);

            _sliding = true;
        }

        if (_sliding)
        {
            _sliderTime += Time.deltaTime;

            if (_sliderTime > _maxSliderTime)
            {
                _sliding = false;

                _animator.SetBool("Slide", false);

                gameObject.GetComponent<BoxCollider>().enabled = true;
            }   
        }
    }
}
