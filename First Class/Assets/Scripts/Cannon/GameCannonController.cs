﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCannonController : MonoBehaviour
{
    const float MINX = -8.20f;
    const float MAXX= 8.20f; 
    
    public int CurrentScore;

    public int CurrentLives;

    public TextMesh ScoreText;
    public TextMesh LivesText;

    public GameObject GameOverText;

    public GameObject RetryText;

    public GameObject WinText;

    public GameObject GoBackText;

   // public GameObject MeteorPrefab;
   
    
    void Start()
    {

        AudioManagerCannon.Instance.PlaySoundEffect(AudioManagerCannon.SoundEffect.Song);

        CurrentScore = 0;

        CurrentLives = 3;

        LivesText = GameObject.Find("LivesText").GetComponent<TextMesh>();

        GameOverText = GameObject.Find("GameOverText");

        RetryText = GameObject.Find("RetryText");

        WinText = GameObject.Find("WinText");

        GoBackText = GameObject.Find("GoBackText");

        // esto quiere decir que la funcion de instanciar bola se repetira muchas veces, y esperara 0 segundos 
        // y nos llamara la funcion por primera vez y luego espera 1.5 segundos entre cada llamada de funcion
        //subsecuente
       // InvokeRepeating("InstantiateBall", 0, 1.5f);

        GameOverText.SetActive(false);

        RetryText.SetActive(false);

        WinText.SetActive(false);

        GoBackText.SetActive(false);
    }


    // Esta funcion lo que hara sera crear bolas que esta en el ballprefab de forma aleatoria en los minimos y
    // los maximos ya especificados anteriormente
  /* void InstantiateMeteor()
    {

       if (CurrentLives <= 0)
        {
            return;
        }      

        Instantiate(BallPrefab, new Vector3(Random.Range(MINX, MAXX),6,0), Quaternion.identity);
    }*/


    public int IncrementScore(){

        CurrentScore++;

        ScoreText.text = CurrentScore.ToString();

        if (CurrentScore == 20)
       {
           StartCoroutine("SendScore");
           WinText.SetActive(true);
           RetryText.SetActive(true);
           GoBackText.SetActive(true);

           AudioManagerCannon.Instance.PlaySoundEffect(AudioManagerCannon.SoundEffect.Win);
       }

        return CurrentScore;
    }


    public int DecrementLives()
    {
       CurrentLives = CurrentLives > 0 ? CurrentLives - 1 : 0;
       LivesText.text = $"Lives: {CurrentLives}"; 

       if (CurrentLives == 0)
       {
           StartCoroutine("SendScore");
           GameOverText.SetActive(true);
           RetryText.SetActive(true);
           GoBackText.SetActive(true);

           AudioManagerCannon.Instance.PlaySoundEffect(AudioManagerCannon.SoundEffect.GameOver);
       }

        return CurrentLives;
    }


    IEnumerator SendScore()
    {
        yield return gameObject.GetComponent<WebServiceCannonClient>().SendWebRequest(CurrentScore);
    }
}
