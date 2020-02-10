using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneController : MonoBehaviour
{
    public GameController gameController;

    void Start()
    {
        // Esto busca en unity un objeto con el nombre de GlobalScriptsText y cuando lo encuentre nos retorna el objeto

        gameController = GameObject.Find("GlobalScriptText").GetComponent<GameController>();
    }

// cuando usamos box collider y activamos la opcion istrigger debemos de usamos esta funcion para 
//que cuando haya collision suceda lo  que se realiza en esta funcion.
    void OnTriggerEnter(Collider other)
    {
        
        //Destroy, destruye un objeto, osea lo desaparece del juego
        Destroy(other.gameObject);
        gameController.DecrementLives();
    }
}


   