using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int CurrentScore;

    public TextMesh ScoreText;
    const float MIN = -8.20f;
    const float MAX= 8.20f; 

    public int CurrentLives;

    public GameObject BallPrefab;
    // Start is called before the first frame update
    void Start()
    {
        CurrentScore = 0;

        CurrentLives = 3;
        // esto quiere decir que la funcion de instanciar bola se repetira muchas veces, y esperara 0 segundos 
        // y nos llamara la funcion por primera vez y luego espera 1.5 segundos entre cada llamada de funcion
        //subsecuente
        InvokeRepeating("InstantiateBall", 0, 1.5f);
    }

    // Esta funcion lo que hara sera crear bolas que esta en el ballprefab de forma aleatoria en los minimos y
    // los maximos ya especificados anteriormente
    void InstantiateBall()
    {
        Instantiate(BallPrefab, new Vector3(Random.Range(MIN, MAX),6,0), Quaternion.identity);
    }

    public int incrementScore(){

        CurrentScore++;

        ScoreText.text = CurrentScore.ToString();

        return CurrentScore;
    }
}
