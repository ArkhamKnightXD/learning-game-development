using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class WebServiceClient : MonoBehaviour
{

    [Serializable]
    public class GravilotaScore
    {
        public int Id;
        public string PlayerName;
        public double Score;
    }
    UnityWebRequest www;
    
    
    void Start()
    {

    }

   public IEnumerator SendWebRequest(double score)
    {
       
       GravilotaScore newScore = new GravilotaScore();

       newScore.Id = 0;
       newScore.PlayerName = "pepe";
       newScore.Score = score;

       string webServiceURL = $"localhost:8888/save/{newScore.PlayerName}/{newScore.Score}";

       www = UnityWebRequest.Put(webServiceURL, JsonUtility.ToJson(newScore));
       www.SetRequestHeader("Content-Type", "application/json");
       yield return www.SendWebRequest();

        Debug.Log(www.downloadHandler.text);
    }
}
