using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping = false;
    WaveConfigSO _currentWave;

    void Start()
    {
        StartCoroutine(SpawnEnemieWaves());    
    }

    public WaveConfigSO GetCurrentWave()
    {
        return _currentWave;
    }

    IEnumerator SpawnEnemieWaves()
    {
        do
        {
            foreach(WaveConfigSO wave in waveConfigs)
            {
                _currentWave = wave;
                for(int i = 0; i < _currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(_currentWave.GetEnemyPrefab(i), _currentWave.GetStartingWaypoint().position, Quaternion.Euler(0,0,180), transform);
                    yield return new WaitForSeconds(_currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping == true);
    }

}
