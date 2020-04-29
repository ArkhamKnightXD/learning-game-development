using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class WebServiceCannonClient : MonoBehaviour
{
    [Serializable]
    public class CannonScore
    {
        public int id;
        public string playerName;
        public float score;
    }

    UnityWebRequest www;

    const string webServiceURL = "localhost:8888/request";
    
    
   public IEnumerator SendWebRequest(float score)
    {
       
       CannonScore newScore = new CannonScore();

       newScore.id = 20;
       newScore.playerName = "Karvin";
       newScore.score = score;

       www = UnityWebRequest.Put(webServiceURL, JsonUtility.ToJson(newScore));
       www.SetRequestHeader("Content-Type", "application/json");
       yield return www.SendWebRequest();

       Debug.Log(www.downloadHandler.text);
    }
}
