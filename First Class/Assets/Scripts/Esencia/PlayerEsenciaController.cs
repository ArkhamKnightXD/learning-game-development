﻿using System.Collections;
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

    public GameObject gameOverText;

        
    private void Awake()
    {
        _animator = GetComponent<Animator>();

        scoreController = GameObject.Find("GlobalScriptsText").GetComponent<ScoreController>();

        gameOverText = GameObject.Find("GameOverText");

        gameOverText.SetActive(false);

        webServiceEsenciaClient = GameObject.Find("GlobalScriptsText").GetComponent<WebServiceEsenciaClient>();
    }

    private void Start()
    {
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
            if (_lives ==0)
            {
                isGameOver = true;
                gameOverText.SetActive(true);
                webServiceEsenciaClient.SaveScore();
            }
            break;
     
            
        }
        AudioManagerEsencia.Instance.PlaySoundEffect(AudioManagerEsencia.SoundEffect.Capture);
        Destroy(other.gameObject);
    }
}
