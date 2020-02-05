using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneController : MonoBehaviour
{
    public GameController gameController;
    public TextMesh LivesText;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("LivesText").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
