using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroidGameController : MonoBehaviour
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

        AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.Song);

        CurrentScore = 0;

        CurrentLives = 3;

        LivesText = GameObject.Find("LivesText").GetComponent<TextMesh>();

        GameOverText = GameObject.Find("GameOverText");

        RetryText = GameObject.Find("RetryText");

        WinText = GameObject.Find("WinText");


        GameOverText.SetActive(false);

        RetryText.SetActive(false);

        WinText.SetActive(false);

    }

    public int IncrementScore(){

        CurrentScore++;

        ScoreText.text = CurrentScore.ToString();

        if (CurrentScore == 10)
       {
           StartCoroutine("SendScore");
           RetryText.SetActive(true);
           WinText.SetActive(true);

           AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.Win);
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

           AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.GameOver);
       }

        return CurrentLives;
    }


    IEnumerator SendScore()
    {
        yield return gameObject.GetComponent<WebServiceClient>().SendWebRequest(CurrentScore);
    }
}
