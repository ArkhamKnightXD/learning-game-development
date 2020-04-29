using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackGravilota : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("GameLoader");
    }
}
