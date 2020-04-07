using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroidGameController : MonoBehaviour
{
    public int CurrentScore;

    public int CurrentLives;

    public TextMesh ScoreText;

    public TextMesh LivesText;

    public TextMesh TimerText;

    public GameObject GameOverText;

    public GameObject RetryText;

    public GameObject WinText;

    public float CurrentTime;

    GameObject _player;

    int count = 0;


    void Start()
    {

        AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.Song);

        CurrentScore = 0;

        CurrentLives = 300;

        CurrentTime = 60;

        LivesText = GameObject.Find("LivesText").GetComponent<TextMesh>();

        GameOverText = GameObject.Find("GameOverText");

        RetryText = GameObject.Find("RetryText");

        WinText = GameObject.Find("WinText");

        TimerText = GameObject.Find("TimerText").GetComponent<TextMesh>();

        _player = GameObject.FindGameObjectWithTag("Player");

        GameOverText.SetActive(false);

        RetryText.SetActive(false);

        WinText.SetActive(false);

    }


    void Update()
    {
       if (_player.gameObject.tag == "PlayerExplosion")
       {
            DecrementTime();   
       }
        

        if (_player.gameObject.tag == "Finish")
       {
            Win();   
       }
    }


    public float DecrementTime()
    {
        
        CurrentTime = CurrentTime > 0 ? CurrentTime - 1 * Time.deltaTime : 0;
        
        TimerText.text = CurrentTime.ToString("0");

        if (CurrentTime == 0 && count == 0)
        {
            count++;
            StartCoroutine("SendScore");

            GameOverText.SetActive(true);

           // RetryText.SetActive(true);

            _player.gameObject.tag = "Death";

            AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.GameOver);
            
        }
       

        return CurrentTime;
    }


    public int IncrementScore(){

        CurrentScore++;

        ScoreText.text = CurrentScore.ToString();

        return CurrentScore;
    }


    public int DecrementLives()
    {
       CurrentLives = CurrentLives > 0 ? CurrentLives - 1 : 0;
       LivesText.text = $"{CurrentLives}"; 
    

       if (CurrentLives == 0 && count == 0)
       {
           count++;
           StartCoroutine("SendScore");
           GameOverText.SetActive(true);
         //  RetryText.SetActive(true);
           _player.gameObject.tag = "Death";

           AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.GameOver);
       }

        return CurrentLives;
    }


    public void Win()
    {
       if (count == 0)
       {
           count++;
           StartCoroutine("SendScore");
           WinText.SetActive(true);
          // RetryText.SetActive(true);

           _player.gameObject.tag = "Finish";

           AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.Win);
       }
    }


    IEnumerator SendScore()
    {
        yield return gameObject.GetComponent<MetroidWebServiceClient>().SendWebRequest(CurrentScore);
    }
}
