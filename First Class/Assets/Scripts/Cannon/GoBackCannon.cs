using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackCannon : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("GameLoader");
    }
}
