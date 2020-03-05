using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonPlayerController : MonoBehaviour
{
    const float MINX = -8f;

    const float MAXX = 8f;

    Vector3 _deltaPosition;

    Vector3 _mousePosition;

    float _speedX = 20f;

    float _triggerSpeed = 10f;

    float _triggerAngle;


    public GameObject CannonBallPrefab;


    void Start()
    {
        _deltaPosition = new Vector3();
    }

    void Update()
    {

        _deltaPosition.y =0;

        _deltaPosition.z =0;

        _deltaPosition.x = Input.GetAxis("Horizontal") * _speedX * Time.deltaTime;

        gameObject.transform.Translate(_deltaPosition);

        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, MINX, MAXX), gameObject.transform.position.y, gameObject.transform.position.z);


        //unity maneja los angulos por defecto en radianes

        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        _deltaPosition.y = _mousePosition.y - gameObject.transform.position.y;

        _deltaPosition.x = _mousePosition.x - gameObject.transform.position.x;

        if (_deltaPosition.x < 0)
        {
            _triggerAngle = Mathf.PI /2;
        }

        else if (_deltaPosition.y < 0)
        {
            _triggerAngle = 0;
        }

        else
        _triggerAngle = Mathf.Atan(_deltaPosition.y / _deltaPosition.x);

        //* Mathf.Rad2Deg esto lo utilizo para llevar de radianes a grados

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(CannonBallPrefab, gameObject.transform.position, Quaternion.identity).GetComponent<CannonBallBehaviour>().Shoot(_triggerSpeed, _triggerAngle);
        }

        
        
    }
}
