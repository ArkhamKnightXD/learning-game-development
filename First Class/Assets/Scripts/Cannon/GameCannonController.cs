using System.Collections;
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

    public GameObject MeteorPrefab;
   
    
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

        GameOverText.SetActive(false);

        RetryText.SetActive(false);

        WinText.SetActive(false);

        GoBackText.SetActive(false);

        InvokeRepeating("InstantiateMeteor", 0, 1.5f);
    }

    
    void InstantiateMeteor()
    {

        if (CurrentLives <= 0)
        {
            return;
        }

        if (CurrentScore > 9)
        {
            return;
        }            

        Instantiate(MeteorPrefab, new Vector3(Random.Range(MINX, MAXX),6,0), Quaternion.identity);
    }


    public int IncrementScore(){

        CurrentScore++;

        ScoreText.text = CurrentScore.ToString();

        if (CurrentScore == 10)
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
