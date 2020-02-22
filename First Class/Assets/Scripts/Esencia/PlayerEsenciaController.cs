using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEsenciaController : MonoBehaviour
{

    public TextMesh PlayerLivesText;

    public GameObject gameOverText;
    
    const float Y_MIN_LIMIT = -4.22f;

    const float Y_MAX_LIMIT = 4.22f;

    Vector3 MovementSpeed = new Vector3(0,10f), _deltaposition;

    ScoreController scoreController;

    int _lives = 3;

    public bool isGameOver;
    
    private void Awake()
    {
        

        scoreController = GameObject.Find("GlobalScriptsText").GetComponent<ScoreController>();
        gameOverText = GameObject.Find("GameOverText");

        gameOverText.SetActive(false);
    }

    private void Start()
    {
        PlayerLivesText.text = _lives.ToString();
    }

    void Update()
    {
        _deltaposition = MovementSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        gameObject.transform.Translate(_deltaposition);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, Mathf.Clamp(gameObject.transform.position.y, Y_MIN_LIMIT, Y_MAX_LIMIT), gameObject.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Blue":
            scoreController.IncrementScore(EssenceType.Blue);
            break;

            case "Red":
            scoreController.IncrementScore(EssenceType.Red);
            break;

            case "Green":
            scoreController.IncrementScore(EssenceType.Green);
            break;

            case "Yellow":
            scoreController.IncrementScore(EssenceType.Yellow);
            break;

            case "Pink":
            scoreController.IncrementScore(EssenceType.Pink);
            break;

            case "Purple":
            scoreController.IncrementScore(EssenceType.Purple);
            break;

            case "Enemy":
            _lives--;
            PlayerLivesText.text = _lives.ToString();
            if (_lives <=0)
            {
                isGameOver = true;
                gameOverText.SetActive(true);
            }
            break;
     
            
        }
        Destroy(other.gameObject);
    }
}
