using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour
{
    Vector3 _currentPosition;
    Vector3 _scrollingSpeed = new Vector3(0.3f,0);

    MeshRenderer _renderer;

    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        _currentPosition += _scrollingSpeed *Time.deltaTime;
        _renderer.material.mainTextureOffset = _currentPosition;
    }
}
