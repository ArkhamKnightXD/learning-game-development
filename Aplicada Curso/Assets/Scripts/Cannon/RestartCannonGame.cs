using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartCannonGame : MonoBehaviour
{
   void OnMouseDown()
    {
        SceneManager.LoadScene("CannonScene");
    }
}
