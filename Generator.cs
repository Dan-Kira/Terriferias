using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    private int enemyQuant;
    public int enemyMaxQuant;
    public float spawnInterval;
    void Start()
    {
        if(enemyQuant < enemyMaxQuant)
        {
            StartCoroutine(enemySpawner());
        }
    }

    IEnumerator enemySpawner()
    {
        while (enemyQuant < enemyMaxQuant)
        {
            yield return new WaitForSeconds(spawnInterval);

            int RandomIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[RandomIndex]);

            enemyQuant++;
        }
    }

    public void DecreaseEnemyCount()
    {
        enemyQuant--;
    }
}
