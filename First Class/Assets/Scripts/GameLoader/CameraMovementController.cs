using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    const float UPPERLIMIT = 2.25f, LOWERRLIMIT = -2.25f;
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

    // Update is called once per frame
    void Update()
    {
        _newPosition.y = Mathf.Clamp(_player.transform.position.y, LOWERRLIMIT,UPPERLIMIT);

        transform.position = _newPosition;
    }
}
