using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 public enum EssenceType 
    {
        Blue = 0,
        Green,
        Pink,
        Purple,
        Red,
        Yellow
    }

public class EsenciaInstatiator : MonoBehaviour
{

    public GameObject BlueEssence,GreenEssence, YellowEssence, PurpleEssence, RedEssence, PinkEssence, Enemy; 

    Dictionary<EssenceType, GameObject> EssencePrefabs;

    float _lastSpawnedTime, _spawnDeltaTime = 0.5f;

    float enemyProbability = 16.7f;

    PlayerEsenciaController _playerEsenciaController;

    private void Awake()
    {
        _playerEsenciaController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEsenciaController>();
    }
    
    void Start()
    {
        _lastSpawnedTime = Time.time;

        EssencePrefabs = new Dictionary<EssenceType, GameObject>
        {
            {EssenceType.Blue, BlueEssence},
            {EssenceType.Red, RedEssence},
            {EssenceType.Green, GreenEssence},
            {EssenceType.Yellow, YellowEssence},
            {EssenceType.Pink, PinkEssence},
            {EssenceType.Purple, PurpleEssence},
        };

    }

    void Update()
    {
        if (!_playerEsenciaController.isGameOver && Time.time - _lastSpawnedTime > _spawnDeltaTime)
        {
            _lastSpawnedTime = Time.time;
            InstatiateEssence();
            InstantiateEnemy();
        }
    }

    void InstatiateEssence()
    {
        Instantiate(EssencePrefabs[(EssenceType)Random.Range(0,6)], new Vector3(10,Random.Range(-4, 5)), Quaternion.identity);
    }

    void InstantiateEnemy()
    {
        if (Random.Range(0f, 100f) <= enemyProbability * 100)
        {
            Instantiate(Enemy, new Vector3(10,Random.Range(-4, 5)), Quaternion.identity);
        }

    }
}
