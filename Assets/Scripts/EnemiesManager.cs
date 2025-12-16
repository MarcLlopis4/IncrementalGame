using System.Collections;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private GameObject enemy;
    bool startedWave = false;
    float waveTimer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startedWave == false) 
        { 
            
            SpawnEnemy();
        
        
        
        }

    }


    private void SpawnEnemy()
    {
        StartCoroutine(EnemySpawnCoroutine());
    }


    IEnumerator EnemySpawnCoroutine()
    {
        startedWave = true;
        while (waveTimer < 10) 
        {

            float randomX = Random.Range(transform.position.x - 45, transform.position.x + 45);
            float randomZ = Random.Range(transform.position.z - 45, transform.position.z + 45);
            GameObject enemyCopy = Instantiate(enemy, new Vector3(randomX, transform.position.y, randomZ), enemy.transform.rotation);

            waveTimer += 1;

            yield return new WaitForSeconds(2);


        }
        
    }
}
