using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    const float MINX = -8.19f;

    const float MAXX = 8.19f;

    Vector3 deltaPosition;

    float speedX = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        deltaPosition = new Vector3(Input.GetAxis("Horizontal"),0) * speedX * Time.deltaTime;

        gameObject.transform.Translate(deltaPosition);

        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, MINX, MAXX), gameObject.transform.position.y, gameObject.transform.position.z);

    }
}
