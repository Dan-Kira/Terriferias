using UnityEngine;
using System.Collections;

public class ItensGenerator : MonoBehaviour
{
    public GameObject[] weaponsPrefab;
    public Transform[] spawnPoints;

    private int weaponsQuant;
    public int weaponsMaxQuant;
    public float spawnInterval;
    void Start()
    {
        if(weaponsQuant < weaponsMaxQuant)
        {
            StartCoroutine(weaponsSpawner());
        }
    }

    IEnumerator weaponsSpawner()
    {
        while (weaponsQuant < weaponsMaxQuant)
        {
            yield return new WaitForSeconds(spawnInterval);

            int RandomIndex = Random.Range(0, spawnPoints.Length);
            int RandomValue = Random.Range(0, weaponsPrefab.Length);
            Instantiate(weaponsPrefab[RandomValue], spawnPoints[RandomIndex]);

            weaponsQuant++;
        }
    }

    public void DecreaseWeaponCount()
    {
        weaponsQuant--;
    }
}
