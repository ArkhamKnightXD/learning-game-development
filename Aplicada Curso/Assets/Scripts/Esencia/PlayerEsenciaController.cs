using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEsenciaController : MonoBehaviour
{
    const float Y_MIN_LIMIT = -4.22f;

    const float Y_MAX_LIMIT = 4.22f;

    int _lives = 3;

    float _lastVerticalAxis;

    Animator _animator;

    Vector3 MovementSpeed = new Vector3(0,10f), _deltaposition;

    ScoreController scoreController;

    WebServiceEsenciaClient webServiceEsenciaClient;

    public bool isGameOver;

    public TextMesh PlayerLivesText;

    public GameObject GameOverText;

    public GameObject RetryText;

    public GameObject WinText;

    public GameObject GoBackText;

        
    private void Awake()
    {
        _animator = GetComponent<Animator>();

        scoreController = GameObject.Find("GlobalScriptsText").GetComponent<ScoreController>();

        GameOverText = GameObject.Find("GameOverText");

        RetryText = GameObject.Find("RetryText");

        WinText = GameObject.Find("WinText");

        GoBackText = GameObject.Find("GoBackText");

        GameOverText.SetActive(false);

        RetryText.SetActive(false);

        WinText.SetActive(false);

        GoBackText.SetActive(false);

        webServiceEsenciaClient = GameObject.Find("GlobalScriptsText").GetComponent<WebServiceEsenciaClient>();
    }


    private void Start()
    {
        AudioManagerEsencia.Instance.PlaySoundEffect(AudioManagerEsencia.SoundEffect.Song);

        PlayerLivesText.text = _lives.ToString();
    }


    void Update()
    {
        if (isGameOver)
        {
            return;
        }

        _deltaposition = MovementSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        gameObject.transform.Translate(_deltaposition);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, Mathf.Clamp(gameObject.transform.position.y, Y_MIN_LIMIT, Y_MAX_LIMIT), gameObject.transform.position.z);


        if (_lastVerticalAxis != Input.GetAxis("Vertical"))
        {
            _lastVerticalAxis = Input.GetAxis("Vertical");

            _animator.SetFloat("VerticalAxis", _lastVerticalAxis);            
        }

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

            if (_lives == 0)
            {
                isGameOver = true;
                GameOverText.SetActive(true);
                RetryText.SetActive(true);

                //WinText.SetActive(false);
                GoBackText.SetActive(true);
                
                AudioManagerEsencia.Instance.PlaySoundEffect(AudioManagerEsencia.SoundEffect.GameOver);

                // Este if me sirve para que no se guarde el score mas de una vez
                if (isGameOver)
                {
                    webServiceEsenciaClient.SaveScore();
                }
                
            }
            break;
     
        }
        

        if (other.gameObject.tag == "Enemy")
        {
            AudioManagerEsencia.Instance.PlaySoundEffect(AudioManagerEsencia.SoundEffect.Explosion);
            Destroy(other.gameObject);    
        }
        else
        {
            AudioManagerEsencia.Instance.PlaySoundEffect(AudioManagerEsencia.SoundEffect.Capture);
            Destroy(other.gameObject);
        }
        
    }
}
