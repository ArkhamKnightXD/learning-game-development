using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebServiceClient : MonoBehaviour
{
     public class GravilotaScore{
        public int id;
        public string PlayerName;
        public float Score;
     }

    UnityWebRequest www;

    const string webServiceUrl = "http://localhost:8888/save"; 

    public IEnumerator SendWebRequest(float newScore){

        GravilotaScore playerScore = new GravilotaScore();

        playerScore.id = 5;

        playerScore.PlayerName = "karvin";

        playerScore.Score = newScore;

        www = new UnityWebRequest(webServiceUrl, JsonUtility.ToJson(playerScore));

        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        Debug.Log(www.downloadHandler.text);     
    }
}
