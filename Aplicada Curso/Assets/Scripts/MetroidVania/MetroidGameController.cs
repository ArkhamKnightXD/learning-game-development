using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroidGameController : MonoBehaviour
{

    const string POWERSLIDERTEXT = "Slide ability enable press left shift to use it";

    const string HIGHJUMPTEXT = "High jump ability enable you can now jump higher";

    const string ANTIACIDTEXT = "Anti acid ability enable now you are invulnerable to the acid";

    const string EXPLOSIONTEXT = "All items collected go back to start point to escape the explosion";

    public int CurrentScore;

    public int CurrentLives;

    public TextMesh ScoreText;

    public TextMesh LivesText;

    public TextMesh TimerText;

    public TextMesh PowerUpText;

    public GameObject GameOverText;

    public GameObject RetryText;

    public GameObject WinText;

    public GameObject PowerUp;

    public float CurrentTime;

    GameObject _player;

    int count = 0;

    int count1 = 0;

    int count2 = 0;

    int count3 = 0;

    int count4 = 0;

    int count5 = 0;


    void Start()
    {

        AudioManagerMetroid.Instance.PlaySoundEffect(AudioManagerMetroid.SoundEffect.Song);

        CurrentScore = 0;

        CurrentLives = 300;

        CurrentTime = 60;

        LivesText = GameObject.Find("LivesText").GetComponent<TextMesh>();

        PowerUpText = GameObject.Find("PowerUpText").GetComponent<TextMesh>();

        GameOverText = GameObject.Find("GameOverText");

        RetryText = GameObject.Find("RetryText");

        WinText = GameObject.Find("WinText");

        PowerUp = GameObject.Find("PowerUpText");

        TimerText = GameObject.Find("TimerText").GetComponent<TextMesh>();

        _player = GameObject.FindGameObjectWithTag("Player");

        GameOverText.SetActive(false);

        RetryText.SetActive(false);

        WinText.SetActive(false);

        PowerUp.SetActive(false);

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


       if (_player.gameObject.tag == "PlayerSlider")
       {
            // Es necesario usar starcoroutine para llamar funciones del tipo IEnumarator
            StartCoroutine(ShowPowerUpSlider(POWERSLIDERTEXT));   
       }


       if (_player.gameObject.tag == "PlayerHighJump")
       {
            StartCoroutine(ShowPowerUpHighJump(HIGHJUMPTEXT));   
       }


       if (_player.gameObject.tag == "PlayerAntiAcid")
       {
            StartCoroutine(ShowPowerUpAntiAcid(ANTIACIDTEXT));   
       }


       if (_player.gameObject.tag == "PlayerExplosion")
       {
            StartCoroutine(ShowPowerUpExplosion(EXPLOSIONTEXT));   
       }
    }



    public IEnumerator ShowPowerUp(string powerUpTextToShow)
    {
 
        if (count1 == 0)
        {
            count1++;

            PowerUp.SetActive(true);

            PowerUpText.text = powerUpTextToShow;

            yield return new WaitForSeconds(5);

            PowerUp.SetActive(false);
        }
        
    }


    public IEnumerator ShowPowerUpSlider(string powerUpTextToShow)
    {
 
        if (count2 == 0)
        {
            count2++;

            PowerUp.SetActive(true);

            PowerUpText.text = powerUpTextToShow;

            yield return new WaitForSeconds(5);

            PowerUp.SetActive(false);
        }
        
    }


    public IEnumerator ShowPowerUpHighJump(string powerUpTextToShow)
    {
 
        if (count3 == 0)
        {
            count3++;

            PowerUp.SetActive(true);

            PowerUpText.text = powerUpTextToShow;

            yield return new WaitForSeconds(5);

            PowerUp.SetActive(false);
        }
        
    }

    public IEnumerator ShowPowerUpAntiAcid(string powerUpTextToShow)
    {
 
        if (count4 == 0)
        {
            count4++;

            PowerUp.SetActive(true);

            PowerUpText.text = powerUpTextToShow;

            yield return new WaitForSeconds(5);

            PowerUp.SetActive(false);
        }
        
    }


    public IEnumerator ShowPowerUpExplosion(string powerUpTextToShow)
    {
 
        if (count5 == 0)
        {
            count5++;

            PowerUp.SetActive(true);

            PowerUpText.text = powerUpTextToShow;

            yield return new WaitForSeconds(5);

            PowerUp.SetActive(false);
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
