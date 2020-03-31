using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerLoader : MonoBehaviour
{
    
    public int CurrentScore;

    public int CurrentLives;

    public TextMesh ScoreText;

    public TextMesh LivesText;

    public GameObject GameOverText;

    public GameObject RetryText;

    public GameObject WinText;


    void Start()
    {

        AudioManagerLoader.Instance.PlaySoundEffect(AudioManagerLoader.SoundEffect.Song);

        CurrentScore = 0;

        CurrentLives = 3;

//        LivesText = GameObject.Find("LivesText").GetComponent<TextMesh>();

        //GameOverText = GameObject.Find("GameOverText");

       // RetryText = GameObject.Find("RetryText");

       // WinText = GameObject.Find("WinText");


        // esto quiere decir que la funcion de instanciar bola se repetira muchas veces, y esperara 0 segundos 
        // y nos llamara la funcion por primera vez y luego espera 1.5 segundos entre cada llamada de funcion
        //subsecuente
      
      //  GameOverText.SetActive(false);

     //   RetryText.SetActive(false);

     //   WinText.SetActive(false);

    }



    /*public int IncrementScore(){

        CurrentScore++;

        ScoreText.text = CurrentScore.ToString();

        if (CurrentScore == 10)
       {
           StartCoroutine("SendScore");
           RetryText.SetActive(true);
           WinText.SetActive(true);

           AudioManagerLoader.Instance.PlaySoundEffect(AudioManagerLoader.SoundEffect.Win);
       }

        return CurrentScore;
    }*/


   /* public int DecrementLives()
    {
       CurrentLives = CurrentLives > 0 ? CurrentLives - 1 : 0;
       LivesText.text = $"Lives: {CurrentLives}"; 

       if (CurrentLives == 0)
       {
           StartCoroutine("SendScore");
           GameOverText.SetActive(true);
           RetryText.SetActive(true);

           AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.GameOver);
       }

        return CurrentLives;
    }*/


/*    IEnumerator SendScore()
    {
        yield return gameObject.GetComponent<WebServiceClient>().SendWebRequest(CurrentScore);
    }*/
}
