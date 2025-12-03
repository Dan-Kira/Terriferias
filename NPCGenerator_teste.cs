using UnityEngine;
using System.Collections;

public class NPCGenerator : MonoBehaviour
{
    public GameObject[] NPCPrefab;
    public Transform[] spawnPoints;

    private int NPCQuant;
    public int NPCMaxQuant;
    public float spawnInterval;
    void Start()
    {
        if(NPCQuant < NPCMaxQuant)
        {
            StartCoroutine(NPCsSpawner());
        }
    }

    IEnumerator NPCsSpawner()
    {
        while (NPCQuant < NPCMaxQuant)
        {
            yield return new WaitForSeconds(spawnInterval);

            int RandomIndex = Random.Range(0, spawnPoints.Length);
            int RandomValue = Random.Range(0, NPCPrefab.Length);
            Instantiate(NPCPrefab[RandomValue], spawnPoints[RandomIndex]);

            NPCQuant++;
        }
    }

    public void DecreaseNPCsCount()
    {
        NPCQuant--;
    }
}
