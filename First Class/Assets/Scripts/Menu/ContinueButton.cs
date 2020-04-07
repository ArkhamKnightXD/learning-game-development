using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    int sceneToContinue;
    
    const float _HOVERSCALEFACTOR = 1.4f;

    GameMenuController _menuController;

    private void Awake()
    {
        _menuController = GameObject.Find("GlobalScriptsText").GetComponent<GameMenuController>();
    }

    public void OnMouseEnter()
    {
        MenuAudioManager.Instance.PlaySoundEffect(MenuAudioManager.SoundEffect.Hover);

        transform.localScale *= _HOVERSCALEFACTOR;
    }

    public void OnMouseExit()
    {
        transform.localScale /= _HOVERSCALEFACTOR;
    }

    public void OnMouseDown()
    {

        if (_menuController.isCanvasActive())
            return;
            
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");

        if (sceneToContinue != 0)
        {
            SceneManager.LoadScene(sceneToContinue);
        }
        else
        {
            return;
        }
    }
}
