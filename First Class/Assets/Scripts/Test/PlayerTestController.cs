using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestController : MonoBehaviour
{
    const float MINX = -8.0f;

    const float MAXX = 8.0f;

    float _speedX = 10f;

    Vector3 deltaPosition;

    string identify;
    
    TestGameController gameController;
    

    void Start()
    {
        gameController = GameObject.Find("GlobalScriptText").GetComponent<TestGameController>();
    }

    
    void Update()
    {
        deltaPosition = new Vector3(Input.GetAxis("Horizontal"),0) * _speedX * Time.deltaTime;

        gameObject.transform.Translate(deltaPosition);

        //GameObject.FindGameObjectsWithTag("Blue")

        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, MINX, MAXX), gameObject.transform.position.y, gameObject.transform.position.z);
    }


    private void OnTriggerEnter(Collider other){

       if (other.gameObject.tag.ToString().Contains("Blue"))
       {
            gameController.DecrementLives(1);

            Destroy(other.gameObject);

            AudioManagerTest.Instance.PlaySoundEffect(AudioManagerTest.SoundEffect.Damage);
       }


       if (other.gameObject.tag.ToString().Contains("Red"))
       {


            gameController.DecrementLives(2);

            Destroy(other.gameObject);

            AudioManagerTest.Instance.PlaySoundEffect(AudioManagerTest.SoundEffect.Damage);
       }


       if (other.gameObject.tag.ToString().Contains("Green"))
       {
            gameController.IncrementLives();

            Destroy(other.gameObject);

            AudioManagerTest.Instance.PlaySoundEffect(AudioManagerTest.SoundEffect.ExtraLive);
       }
       
    }
}
