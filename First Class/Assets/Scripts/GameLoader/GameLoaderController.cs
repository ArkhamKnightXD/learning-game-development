using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoaderController : MonoBehaviour
{

    string _sceneName;
    //Esta funcion se ejecuta mientras se este colissionando
    public void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Submit"))
        {
            switch (gameObject.name)
            {
                case "Game1Loader":
                _sceneName = "SampleScene";
                    break;

                case "Game2Loader":
                _sceneName = "Esencia";
                    break;

                case "Game3Loader":
                _sceneName = "Cannon";
                    break;

                case "Game4Loader":
                _sceneName = "ExplorationLevel";
                    break;
            
            }
            SceneManager.LoadScene(_sceneName);
        }
    }

}
