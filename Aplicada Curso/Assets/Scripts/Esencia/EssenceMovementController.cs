using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceMovementController : MonoBehaviour
{
    float _XAcceleration = -9.8f;

    float _XCurrentSpeed = 0;

    Vector3 _deltaPosition;


    void Update()
    {
        _deltaPosition = new Vector3(_XCurrentSpeed * Time.deltaTime + (_XAcceleration* Mathf.Pow(Time.deltaTime,2))/2,0);
        
        gameObject.transform.Translate(_deltaPosition);

        _XCurrentSpeed += _XAcceleration * Time.deltaTime;
    }
}
