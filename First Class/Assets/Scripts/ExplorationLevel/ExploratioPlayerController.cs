using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploratioPlayerController : MonoBehaviour
{
    Vector3 _movementSpeed = new Vector3(5,5), _runningSpeed = new Vector3(15,15);

    Rigidbody _rigidBody;

    Vector3 _currentSpeed = new Vector3();

    Animator _animator;

    SpriteRenderer _renderer;

    bool _isEnemy;

    const float ENEMYMOVEDISTANCE = 5f, ENEMYATTACKDISTANCE = 2f;

    GameObject player;

    private void Awake()
    {
        Physics.IgnoreLayerCollision(8,10);

    }

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();

        _isEnemy = gameObject.tag == "Enemy"; 
    }

    void Update()
    {
        if (!_isEnemy)
        {
            _currentSpeed.x = Input.GetAxis("Horizontal") * (Input.GetButton("Fire3") ? _runningSpeed.x : _movementSpeed.x);
    
            _currentSpeed.y = Input.GetAxis("Vertical") * (Input.GetButton("Fire3") ? _runningSpeed.y : _movementSpeed.y);

            _animator.SetBool("attack", Input.GetButton("Fire1"));    
        }


      /*  else
        {
            if (Vector3.Distance(gameObject.transform.position,player.transform.position) < ENEMYATTACKDISTANCE)
            {
                _animator.SetBool("attack", true; 
            }
            else
            {
                _animator.SetBool("attack", false); 
            }

            if (Vector3.Distance(gameObject.transform.position,player.transform.position) < ENEMYMOVEDISTANCE)
            {
                Vector3.MoveTowards(gameObject.transform.position, player.transform.position, 10);
            }
        }*/

        _animator.SetFloat("speed", _currentSpeed.magnitude);



        if (_currentSpeed != Vector3.zero)
        {
            _rigidBody.MovePosition(transform.position + _currentSpeed * Time.deltaTime);    
        }

        if (_currentSpeed.x < 0)
        {
            _renderer.flipX = true;
        }

        else
        {
            _renderer.flipX = false;
        }
    }
}
