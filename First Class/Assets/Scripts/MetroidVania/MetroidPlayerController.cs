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

    float maxJumpingHighTime = 2f;

    bool isDead = false;

    float deathTime;

    float maxDeathTime = 20f;

   
    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _renderer = GetComponent<SpriteRenderer>();
        
        _player = GameObject.FindGameObjectWithTag("Player");

    }


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {

        if (_player.gameObject.tag == "Player" || _player.gameObject.tag == "PlayerSlider")
        {
            Jump();    
        }
        
        if (_player.gameObject.tag != "Death" && _player.gameObject.tag != "Finish")
        {
            _newPosition.x = Input.GetAxis("Horizontal") * (Input.GetButton("Fire2") ? _runningSpeed.x : _movementSpeed.x);

            _renderer.flipX=_newPosition.x < 0;


            _animator.SetFloat("Speed",_newPosition.magnitude);
       
            _rigidbody.MovePosition(transform.position + _newPosition* Time.deltaTime);
        }
       


        if (_player.gameObject.tag == "PlayerSlider")
        {
            Slide();    
        }
        

        if (_player.gameObject.tag == "PlayerHighJump" || _player.gameObject.tag == "PlayerAntiAcid")
        {
            Slide();
            HighJump();    
        }


        if (_player.gameObject.tag == "PlayerAttack")
        {
            Slide();

            HighJump();

            _animator.SetBool("Attack", Input.GetButton("Fire1"));    
        }

        if (_player.gameObject.tag == "PlayerExplosion")
        {
            Slide();

            HighJump();

            _animator.SetBool("Attack", Input.GetButton("Fire1"));    
        }

        if (_player.gameObject.tag == "Death")
        {

            Die();    
            
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

            AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.Jump);
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
        if (Input.GetButton("Jump") && !jumping)
        {
            jumpTime = 0f;

            _rigidbody.AddForce(transform.up * 470f);
            _animator.SetBool("Jump", true);

            jumping = true;

            AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.Jump);
        }

        if (jumping)
        {
            jumpTime += Time.deltaTime;

            if (jumpTime > maxJumpingHighTime)
            {
                jumping = false;

                _animator.SetBool("Jump", false);

            }   
        }
    }


    private void Slide()
    {
        if (Input.GetButton("Fire3") && !_sliding)
        {
            _sliderTime =0f;

            gameObject.GetComponent<BoxCollider>().enabled = false;
            _animator.SetBool("Slide", true);

            _sliding = true;

            AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.Attack);
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


    private void Die()
    {

        if (!isDead)
        {
            deathTime = 0f;

            _animator.SetBool("Die", true);

            isDead = true;
        }

        if (isDead)
        {
            deathTime += Time.deltaTime;

            if (deathTime > maxDeathTime)
            {
                isDead = false;

                _animator.SetBool("Die", false);

            }   
        }

    }
}
