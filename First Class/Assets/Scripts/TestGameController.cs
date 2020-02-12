using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameController : MonoBehaviour
{

    const float MINX = -8.20f;
    const float MAXX= 2.60f;

    const float TOWERPOSITION= -7.79f; 

    const float MINY = -2.4f;

    const float MAXY = 4.10f;
    public int CurrentScore;

    public int CurrentLives;

    public TextMesh ScoreText;
    public TextMesh LivesText;

    public GameObject GameOverText;

    public GameObject BlueCube;

    public GameObject GreenCube;

    Vector3 BlueCubePosition;

    
    Vector3 BlueCubePosition2;

    Vector3 GreenCubePosition;

    Vector3 GreenCubePosition2;

    void Start()
    {
        CurrentScore = 0;

        CurrentLives = 10;

        LivesText = GameObject.Find("LivesText").GetComponent<TextMesh>();

        GameOverText = GameObject.Find("GameOverText");

        GameOverText.SetActive(false);

        InvokeRepeating("InstantiateBlueCube", 6, 10.0f);

        InvokeRepeating("InstantiateGreenCube", 12, 8.0f);

        InvokeRepeating("InstantiateCubeTower", 0, 25.0f);


    }


    void InstantiateBlueCube()
    {

       if (CurrentLives <= 0)
        {
            GameOverText.SetActive(true);
        }      


        BlueCubePosition = new Vector3(Random.Range(MINX, MAXX),6,0);

        Instantiate(BlueCube, BlueCubePosition, Quaternion.identity);
        
    }


     void InstantiateGreenCube()
    {

       if (CurrentLives <= 0)
        {
            GameOverText.SetActive(true);
        }      


        GreenCubePosition = new Vector3(Random.Range(MINX, MAXX),6,0);
     
        Instantiate(GreenCube, GreenCubePosition, Quaternion.identity);
        
    }


     void InstantiateCubeTower()
    {

       if (CurrentLives <= 0)
        {
            GameOverText.SetActive(true);
        }      


        BlueCubePosition = new Vector3(TOWERPOSITION,MINY,0);

        GreenCubePosition = new Vector3(TOWERPOSITION,0,0);

        BlueCubePosition2 = new Vector3(TOWERPOSITION,2,0);
     

        Instantiate(GreenCube, GreenCubePosition, Quaternion.identity);
        
        Instantiate(BlueCube, BlueCubePosition, Quaternion.identity);

        Instantiate(BlueCube, BlueCubePosition2, Quaternion.identity);

    }


    private void OnTriggerEnter(Collider other){


        Destroy(other.gameObject);
    }


     public int IncrementScore(){

        CurrentScore++;

        ScoreText.text = CurrentScore.ToString();

        return CurrentScore;
    }
}
