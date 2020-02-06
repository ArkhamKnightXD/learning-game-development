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

    public GameObject BallPrefab;

    //Estas dos constante representan el minimo y el maximo valor que puede tener la canasta en el juego
    // Osea establecemos estos limites para que las pelotas no puedan ser generadas fuera de la pantalla de juego    
    const float MINX = -8.20f;
    const float MAXX= 8.20f; 

    
    void Start()
    {
        CurrentScore = 0;

        CurrentLives = 3;

        LivesText = GameObject.Find("LivesText").GetComponent<TextMesh>();

        GameOverText = GameObject.Find("GameOverText");

        // esto quiere decir que la funcion de instanciar bola se repetira muchas veces, y esperara 0 segundos 
        // y nos llamara la funcion por primera vez y luego espera 1.5 segundos entre cada llamada de funcion
        //subsecuente
        InvokeRepeating("InstantiateBall", 0, 1.5f);

        GameOverText.SetActive(false);
    }

    // Esta funcion lo que hara sera crear bolas que esta en el ballprefab de forma aleatoria en los minimos y
    // los maximos ya especificados anteriormente
    void InstantiateBall()
    {

       if (CurrentLives <= 0)
        {
            GameOverText.SetActive(true);
            return;
        }      

        Instantiate(BallPrefab, new Vector3(Random.Range(MINX, MAXX),6,0), Quaternion.identity);
    }

    public int IncrementScore(){

        CurrentScore++;

        ScoreText.text = CurrentScore.ToString();

        return CurrentScore;
    }

    public int DecrementLives()
    {
       CurrentLives = CurrentLives > 0 ? CurrentLives - 1 : 0;
       LivesText.text = $"Vidas: {CurrentLives}"; 

        return 0;
    }
}
