using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    bool canJump;

    // Nota cuando trabajamos script en unity la mayoria de las veces los que vamos a querer hacer es modificar parametros de un componente

    // Start is called before the first frame update
    void Start()
    {

        

       

    }

    // Update is called once per frame
    void Update()
    {
        // el parametro position solo acepta un vector position asi que no podemos simplemente agregar un valor a esto, por lo tanto debemos utilizar un
        //vector 3 que es de 3 dimensiones y tiene 3 valores

        //la forma correcta para determinar cuantas unidades se debe de mover el personaje es usando deltatime, que nos devuelve cuantos segundos ha tardado en renderizarse el ultimo frame

        //Esto tiene una forma larga que es esta
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x + 3 *Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);


        //Y una forma corta 
        // gameObject.transform.Translate(3 * Time.deltaTime, 0, 0);


        // De esta forma utilizo las teclas para mover el personaje, esta forma no es la conveniente si planeamos utilizar fisicas, pero funciona

        /*  if (Input.GetKey("right"))
          {
              gameObject.transform.Translate(3 * Time.deltaTime, 0, 0);

          }


          if (Input.GetKey("left"))
          {
              gameObject.transform.Translate(-3 * Time.deltaTime, 0, 0);

          }*/


        //Mover personaje pero con fisicas

        if (Input.GetKey("right"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f * Time.deltaTime,0));

        }


        if (Input.GetKey("left"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000f * Time.deltaTime, 0));

        }

        //Salto utilizando gravedad

        // la diferencia entre getkey y getkeydown, es que en getkey hay que dejar pulsada la tecla todo el tiempo
        //y en getkeydown no

        if (Input.GetKeyDown("up")) 
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100f));
        }

      //  ManageJump();

    }


    // forma para hacer saltar al personaje con fisicas





    // Forma para hacer saltar al personaje sin fisicas

   /* void ManageJump() {

        if (gameObject.transform.position.y <= 0) {

            canJump = true;
        }


        if (Input.GetKey("up") && canJump && gameObject.transform.position.y < 10)
        {

            gameObject.transform.Translate(0, 6 * Time.deltaTime, 0);

        }

        else {

            canJump = false;


            if (gameObject.transform.position.y > 0) {

                gameObject.transform.Translate(0, 6 * Time.deltaTime, 0);
            }



        }


    }*/



}
