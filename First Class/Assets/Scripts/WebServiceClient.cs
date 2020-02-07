using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebServiceClient : MonoBehaviour
{

     public class GravilotaScore{
         int id;
         string PlayerName;
         float Score;
     }
    UnityWebRequest www;

     const string webServiceUrl = "http://localhost:64844/api/values"; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SendWebRequest");
    }

    // Update is called once per frame

    IEnumerator SendWebRequest(){

        GravilotaScore newScore = new GravilotaScore();

        newScore.id = 5;

        www = new UnityWebRequest(webServiceUrl, "POST");
        www.SetRequestHeader("Conten-Type", "application/json");

        yield return www.SendWebRequest();

        Debug.Log(www.downloadHandler.text);     
    }
    void Update()
    {

        
    }
}
