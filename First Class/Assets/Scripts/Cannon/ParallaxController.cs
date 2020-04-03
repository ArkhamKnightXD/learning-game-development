using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    MeshRenderer _renderer;

    float _maxSpeed = 0.02f, _currentSpeed;

    const float MAXSPEED = 20f;


    void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }


    void Start()
    {
        _currentSpeed = (1 - gameObject.transform.position.z /MAXSPEED) *  _maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        _renderer.material.mainTextureOffset = new Vector2(Camera.main.transform.position.x * _maxSpeed, 0);
    }
}
