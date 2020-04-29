using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementStoreController : MonoBehaviour
{
    const float UPPERLIMIT = 0.10f, LOWERRLIMIT = -0.10f;
    GameObject _player;

    Vector3 _newPosition;

    
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Start()
    {
        _newPosition = gameObject.transform.position;
    }


    void Update()
    {
        _newPosition.y = Mathf.Clamp(_player.transform.position.y, LOWERRLIMIT,UPPERLIMIT);

        transform.position = _newPosition;
    }
}
