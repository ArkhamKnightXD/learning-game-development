using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackEsencia : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("GameLoader");
    }
}
