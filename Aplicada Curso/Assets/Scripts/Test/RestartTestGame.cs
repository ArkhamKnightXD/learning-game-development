using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartTestGame : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("TestScene");
    }
}
