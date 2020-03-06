using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class WebServiceEsenciaClient : MonoBehaviour
{
    [Serializable]
    public class Esence
    {
        public int id;
        public string playerName;
        public float greenScore;
        public float yellowScore;
        public float redScore;
        public float blueScore;
        public float pinkScore;
        public float purpleScore;
    }


    ScoreController scoreController;


    public void Awake()
    {
        scoreController = GetComponent<ScoreController>();
    }


    public void SaveScore()
    {
        StartCoroutine(SendWebRequest());
    }

    
    UnityWebRequest www1;

    const string webServiceURLEsence = "localhost:8888/esence/request";

    const string webServiceURLEsence2 = "localhost:8888/esence/scores";

    
    public IEnumerator SendWebRequest()
    {
       
       Esence newScore = new Esence();

       newScore.id = 0;

       newScore.playerName = "Karvin";

       newScore.greenScore = scoreController._scores[1];

       newScore.yellowScore = scoreController._scores[5];

       newScore.redScore = scoreController._scores[4];

       newScore.blueScore = scoreController._scores[0];

       newScore.pinkScore = scoreController._scores[2];

       newScore.purpleScore = scoreController._scores[3];
       

       www1 = UnityWebRequest.Put(webServiceURLEsence, JsonUtility.ToJson(newScore));

       www1.SetRequestHeader("Content-Type", "application/json");

       yield return www1.SendWebRequest();

       Debug.Log(www1.downloadHandler.text);
    }


    public IEnumerator GetTopScore()
    {
        www1 = UnityWebRequest.Get(webServiceURLEsence2);

        www1.SetRequestHeader("Content-Type", "application/json");

        yield return www1.SendWebRequest(); 
    }
}
