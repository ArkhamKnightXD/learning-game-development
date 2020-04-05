using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetroidGameLoaderController : MonoBehaviour
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
                _sceneName = "GameLoader";
                    break;

            
                case "GameStoreLoader":
                _sceneName = "StoreScene";
                    break;
            
            }
            SceneManager.LoadScene(_sceneName);
        }
    }

}
