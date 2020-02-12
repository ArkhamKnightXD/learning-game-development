using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Nota poner siempre las variables y objetos que utilizaremos fuera de la funcion update y start

    //Estas dos constante son para definir el rango maximo de X que se puede mover nuestro player, osea la canasta
    const float MINX = -8.20f;

    const float MAXX = 8.20f;

    float _speedX = 10f;

    Vector3 deltaPosition;
    
    GameController gameController;
    

    void Start()
    {
        gameController = GameObject.Find("GlobalScriptText").GetComponent<GameController>();
    }

    //tenemos update y fixedupdate time.deltatime debe de usarse cuando se usa solo update, de lo contrari no
    void Update()
    {
        // Aqui basicamente consigo la distancia a la que se debe mover mi objeto
        deltaPosition = new Vector3(Input.GetAxis("Horizontal"),0) * _speedX * Time.deltaTime;

        // translate es como un += para la posicion.
        gameObject.transform.Translate(deltaPosition);

        //GameObject.FindGameObjectsWithTag("Blue")

        //gameObject.tag
        // mathf.Clamp sirve para restringir el movimiento de x entre los valores minimos y maximos especificados
        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, MINX, MAXX), gameObject.transform.position.y, gameObject.transform.position.z);
    }


    private void OnTriggerEnter(Collider other){

        gameController.IncrementScore();

        Destroy(other.gameObject);
    }
}
