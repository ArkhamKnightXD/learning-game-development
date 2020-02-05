using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    const float MIN = -8.20f;
    const float MAX= 8.20f; 

    float _speedX = 15f;

    Vector3 deltaPosition;
    
    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("Global Script Text").GetComponent<GameController>();
    }

    // Update is called once per frame
    //tenemos update y fixedupdate time.deltatime debe de usarse cuando se usa solo update, de lo contrari no
    void Update()
    {
        // translate es como un += 
        gameObject.transform.Translate(new Vector3(Input.GetAxis("Horizontal"),0) * _speedX * Time.deltaTime );

        gameObject.transform.Translate(deltaPosition);

        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, MIN, MAX), gameObject.transform.position.y, gameObject.transform.position.z);
    }


// cuando usamos con un element trigger usamos esta funcion para que cuando haya collision suceda lo 
// que se realiza en esta funcion.
    private void OnTriggerEnter(Collider other){

        gameController.incrementScore();

        Destroy(other.gameObject);

    }
}
