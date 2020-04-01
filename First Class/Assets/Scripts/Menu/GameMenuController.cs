using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuController : MonoBehaviour
{

    GameObject _canvas;

    bool _isActive;
    private void Awake()
    {
        _canvas = GameObject.Find("GameOptionsDialog");

        _canvas.SetActive(false);
    }


    public void ShowGameOptions()
    {
        _canvas.SetActive(true);
    }


    public void HideGameOptions()
    {
        _canvas.SetActive(false);
    }


   /* public bool isCanvasActive()
    {
        
    }*/
}
