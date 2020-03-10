using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int CurrentScore;

    public int CurrentLives;

    public TextMesh ScoreText;

    public TextMesh LivesText;

    public GameObject GameOverText;

    public GameObject RetryText;

    public GameObject WinText;

    //cod example  _playerEsenciaController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEsenciaController>();

    void Start()
    {
        AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.GameSong);

        //definiendo los valores iniciales del score y de las vidas
        CurrentScore = 0;
        CurrentLives = 1;


        // Buscando los distintos objetos por su nombre para poder utilizarlos ene sta clase
        LivesText = GameObject.Find("LivesText").GetComponent<TextMesh>();
        GameOverText = GameObject.Find("GameOverText");
        WinText = GameObject.Find("WinText");
        RetryText = GameObject.Find("RetryText");

        RetryText.SetActive(false);
        GameOverText.SetActive(false);
        WinText.SetActive(false);
        
    }



    public int IncrementScore(){

        CurrentScore++;

        ScoreText.text = CurrentScore.ToString();

        return CurrentScore;
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

    // funcion encargada de mandar el score a webservice client, no toma parametros esta funcion
    IEnumerator SendScore()
    {
        yield return gameObject.GetComponent<WebServiceClient>().SendWebRequest(CurrentScore);
    }
    void Update()
    {
        
    }
}
