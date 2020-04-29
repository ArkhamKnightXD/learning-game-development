using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlappyController : MonoBehaviour
{
    public int CurrentScore;

    public int CurrentLives;

    public TextMesh ScoreText;

    public GameObject GameOverText;

    public TextMesh LivesText;


    void Start()
    {
        AudioManagerFlappy.Instance.PlaySoundEffect(AudioManagerFlappy.SoundEffect.GameSong);

        CurrentScore = 0;
        CurrentLives = 1;
        
        GameOverText = GameObject.Find("GameOverText");

        GameOverText.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public int IncrementScore()
    {

        CurrentScore += 1;

        ScoreText.text = CurrentScore.ToString();

        return CurrentScore;
    }

    public int GameOverByFall()
    {
        CurrentLives = 0;
        LivesText.text = $"Lives: {CurrentLives}"; 

        StartCoroutine("SendScore");

        GameOverText.SetActive(true);


        AudioManagerFlappy.Instance.PlaySoundEffect(AudioManagerFlappy.SoundEffect.GameOver);

        return CurrentLives;

    }

    // funcion encargada de mandar el score a webservice client, no toma parametros esta funcion
    IEnumerator SendScore()
    {
        yield return gameObject.GetComponent<WebServiceFlappyClient>().SendWebRequest(CurrentScore);
    }
}
