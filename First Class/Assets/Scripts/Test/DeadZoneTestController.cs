using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneTestController : MonoBehaviour
{
    public TestGameController gameController;

    void Start()
    {
    

        gameController = GameObject.Find("GlobalScriptText").GetComponent<TestGameController>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag.ToString().Contains("Blue"))
       {
            Destroy(other.gameObject);
            gameController.IncrementScore();

            AudioManagerTest.Instance.PlaySoundEffect(AudioManagerTest.SoundEffect.Point);
       }
       

       if (other.gameObject.tag.ToString().Contains("Red"))
       {
            Destroy(other.gameObject);

            AudioManagerTest.Instance.PlaySoundEffect(AudioManagerTest.SoundEffect.Point);
       }

       if (other.gameObject.tag.ToString().Contains("Green"))
       {
            Destroy(other.gameObject);

            AudioManagerTest.Instance.PlaySoundEffect(AudioManagerTest.SoundEffect.Point);
       }
        
        
    }
}
