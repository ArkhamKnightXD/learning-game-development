using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemLoaderController : MonoBehaviour
{

    string _sceneName;

    
    //Esta funcion se ejecuta mientras se este colissionando
    public void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Submit"))
        {
            switch (gameObject.name)
            {
                case "Item1Loader":
                _sceneName = "SampleScene";
                    break;

                case "Item2Loader":
                _sceneName = "EsenciaScene";
                    break;

                case "Item3Loader":
                _sceneName = "CannonScene";
                    break;

                case "Item4Loader":
                _sceneName = "TestScene";
                    break;


                case "GameExitLoader":
                _sceneName = "GameLoader";
                    break;
            
            }
            SceneManager.LoadScene(_sceneName);
        }
    }

}
