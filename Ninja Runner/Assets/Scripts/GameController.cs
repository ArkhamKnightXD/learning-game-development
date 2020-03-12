using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int CurrentScore;

    public int CurrentLives;

    public float CurrentTime;

    public TextMesh ScoreText;

    public TextMesh LivesText;

    public TextMesh TimerText;

    public GameObject GameOverText;

    public GameObject RetryText;

    public GameObject WinText;


    void Start()
    {
        AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.GameSong);

        //definiendo los valores iniciales del score y de las vidas
        CurrentScore = 0;
        CurrentLives = 1;
        CurrentTime = 240;


        // Buscando los distintos objetos por su nombre para poder utilizarlos ene sta clase
        LivesText = GameObject.Find("LivesText").GetComponent<TextMesh>();
        TimerText = GameObject.Find("TimerText").GetComponent<TextMesh>();
        GameOverText = GameObject.Find("GameOverText");
        WinText = GameObject.Find("WinText");
        RetryText = GameObject.Find("RetryText");

        RetryText.SetActive(false);
        GameOverText.SetActive(false);
        WinText.SetActive(false);
        
    }


    void Update()
    {
       
        DecrementTime();
    
    }

     
     //Funcion encargada de restar 1  al tiempo esta restara uno por cada 60 frames 
    public float DecrementTime()
    {
        // Aqui hago que se reste 1 al timer por cada 60 frames que equivale a 1 segundo, hago esto multiplicando 1 * time.deltatime
       // CurrentTime -= 1 * Time.deltaTime;

        CurrentTime = CurrentTime > 0 ? CurrentTime - 1 * Time.deltaTime : 0;
        

        //El 0 lo pongo dentro de la funcion tostring para que no me muestre los decimaes, sino simplemente el numero entero
        TimerText.text = CurrentTime.ToString("0");


        //El send score y el gameover sound dan error debido a que esta funcion se llama 60 veces por segundo

        if (CurrentTime == 0)
        {

          //  StartCoroutine("SendScore");

            GameOverText.SetActive(true);

            RetryText.SetActive(true);

           // AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.GameOver);
            
        }
       

        return CurrentTime;
    }


    public int IncrementScore()
    {

        CurrentScore += 50;

        ScoreText.text = CurrentScore.ToString();

        return CurrentScore;
    }



    public int IncrementLives()
    {

        CurrentLives++;
       
        LivesText.text = $"Lives: {CurrentLives}"; 

        return CurrentLives;
    }



    public void Win()
    {

        StartCoroutine("SendScore");

        WinText.SetActive(true);

        RetryText.SetActive(true);

        AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.Win);

    }

    
     //Esta funcion se encarga de disminuir las vidas en el juego de 1 en 1, no toma parametros y retorna un entero
    //que es la vida actual, ademas de que cuando las vidas llegan a 0 se pierde automaticamente y al mismo tiempo
    // crea un hilo para que se mande el score tan pronto se acabe el juego y por ultimo toca un sonido de game over
    public int DecrementLives()
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
    }


    public int GameOverByFall()
    {
        CurrentLives = 0;
        LivesText.text = $"Lives: {CurrentLives}"; 

        StartCoroutine("SendScore");

        GameOverText.SetActive(true);

        RetryText.SetActive(true);

        AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.GameOver);

        return CurrentLives;

    }

    // funcion encargada de mandar el score a webservice client, no toma parametros esta funcion
    IEnumerator SendScore()
    {
        yield return gameObject.GetComponent<WebServiceClient>().SendWebRequest(CurrentScore);
    }

}
