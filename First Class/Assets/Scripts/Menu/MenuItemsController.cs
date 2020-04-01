using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuItemsController : MonoBehaviour
{
    const float _HOVERSCALEFACTOR = 1.4f;

    GameMenuController _menuController;

    private void Awake()
    {
        _menuController = GameObject.Find("GlobalScriptsText").GetComponent<GameMenuController>();
    }

    public void OnMouseEnter()
    {
        transform.localScale *= _HOVERSCALEFACTOR;
    }

    public void OnMouseExit()
    {
        transform.localScale /= _HOVERSCALEFACTOR;
    }

    //funciona parecido a onmousedown
    public void OnMouseUp()
    {
       /* if (_menuController.isActiveAndEnabled())
            return;
        {
            
        }*/

        switch (gameObject.name)
        {
            case "Play":
            SceneManager.LoadScene("GameLoader");
            break;

            case "Option":
            _menuController.ShowGameOptions();
            break;

            case "Exit":
            SceneManager.LoadScene("GameLoader");
            break;

        }

    }


    public void AcceptDialog()
    {
        _menuController.HideGameOptions();
    }


    public void CancelDialog()
    {
        _menuController.HideGameOptions();
    }


    public void OnplayerNameChanged(InputField input)
    {
        //GameMenuController.CurrentGame.PlayerName = Input
    }
}
