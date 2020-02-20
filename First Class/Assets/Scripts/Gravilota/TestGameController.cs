using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameController : MonoBehaviour
{

    const float MINX = -8.0f;
    const float MAXX= 8.0f;

    public int CurrentScore;

    public int CurrentLives;

    public TextMesh ScoreText;
    public TextMesh LivesText;

    public GameObject GameOverText;

    public GameObject RetryText;

    public GameObject BlueCube;

    public GameObject GreenCube;

    public GameObject RedCube;

    Vector3 BlueCubePosition;

    Vector3 GreenCubePosition;

    Vector3 RedCubePosition;


    void Start()
    {

        AudioManagerTest.Instance.PlaySoundEffect(AudioManagerTest.SoundEffect.Song);
        CurrentScore = 0;

        CurrentLives = 5;

        LivesText = GameObject.Find("LivesText").GetComponent<TextMesh>();

        GameOverText = GameObject.Find("GameOverText");

        RetryText = GameObject.Find("RetryText");

        RetryText.SetActive(false);

        GameOverText.SetActive(false);
        

        InvokeRepeating("InstantiateBlueCube", 0, 2.0f);

        InvokeRepeating("InstantiateGreenCube", 15, 10.0f);

        InvokeRepeating("InstantiateRedCube", 9, 7.0f);

    }


    void InstantiateBlueCube()
    {

       if (CurrentLives <= 0)
        {
            GameOverText.SetActive(true);
            return;
        }      


        BlueCubePosition = new Vector3(Random.Range(MINX, MAXX),6,0);

        Instantiate(BlueCube, BlueCubePosition, Quaternion.identity);
        
    }


    void InstantiateGreenCube()
    {

       if (CurrentLives <= 0)
        {
            GameOverText.SetActive(true);
            return;
        }      


        GreenCubePosition = new Vector3(Random.Range(MINX, MAXX),6,0);
     
        Instantiate(GreenCube, GreenCubePosition, Quaternion.identity);
        
    }


    void InstantiateRedCube()
    {

       if (CurrentLives <= 0)
        {
            GameOverText.SetActive(true);
            return;
        }      


        RedCubePosition = new Vector3(Random.Range(MINX, MAXX),6,0);
     
        Instantiate(RedCube, RedCubePosition, Quaternion.identity);
        
    }



     public int IncrementScore(){

        CurrentScore++;

        ScoreText.text = CurrentScore.ToString();

        return CurrentScore;
    }


    public int IncrementLives()
    {
       CurrentLives++;
       LivesText.text = $"Vidas: {CurrentLives}"; 


       return CurrentLives;
    }

    public int DecrementLives(int identifier)
    {

       if (identifier == 1)
       {

            CurrentLives = CurrentLives > 0 ? CurrentLives - 1 : 0;
            LivesText.text = $"Vidas: {CurrentLives}";           
       } 


       if (identifier == 2)
       {

            CurrentLives = CurrentLives > 1? CurrentLives - 2 : 0;
            LivesText.text = $"Vidas: {CurrentLives}";           
       } 
 

       if (CurrentLives <= 0)
       {
           StartCoroutine("SendScore");
           GameOverText.SetActive(true);
           RetryText.SetActive(true);
           AudioManagerTest.Instance.PlaySoundEffect(AudioManagerTest.SoundEffect.GameOver);
       }

        return CurrentLives;
    }

    IEnumerator SendScore()
    {
        yield return gameObject.GetComponent<WebServiceClient>().SendWebRequest(CurrentScore);
    }


    /*IEnumerator GetScore()
    {
        yield return gameObject.GetComponent<WebServiceClient>().Send;
    }*/
}
