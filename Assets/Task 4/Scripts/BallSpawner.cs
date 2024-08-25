using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public static Action<Transform> BallSpawned;
    public static Action BallSpawnStopped;

    public static bool IsWork;

    [SerializeField] private Transform _objForSpawn;
    [SerializeField] private Transform _spawnObjHolder;
    [SerializeField] private float _spawnTime;
    private float _minSpawnPointX = -6;
    private float _maxSpawnPointX = 7;

    private void Start()
    {
        IsWork = true;
    }
    private void Update()
    {
        if (IsWork)
        {
            if (_spawnTime > 0)
            {
                _spawnTime -= Time.deltaTime;
            }
            else
            {
                StopCoroutine(nameof(SpawnObject));
                IsWork = false;
                BallSpawnStopped();
            }
        }
    }

    private IEnumerator SpawnObject()
    {
        Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(_minSpawnPointX, _maxSpawnPointX), transform.position.y, transform.position.z);
        Transform spawnObj = Instantiate(_objForSpawn, spawnPosition, Quaternion.identity, _spawnObjHolder);
        AddBallComponent(spawnObj);
        BallSpawned?.Invoke(spawnObj);

        yield return new WaitForSeconds(1f);

        StartCoroutine(nameof(SpawnObject));
    }

    private void AddBallComponent(Transform obj)
    {
        int rand = UnityEngine.Random.Range(1, 4);
        switch (rand)
        {
            case 1:
                obj.AddComponent<WhiteBall>();
                break;
            case 2:
                obj.AddComponent<RedBall>();
                break;
            case 3:
                obj.AddComponent<GreenBall>();
                break;
        }
    }
    public void StartSpawn()
    {
        StartCoroutine(nameof(SpawnObject));
    }
}
