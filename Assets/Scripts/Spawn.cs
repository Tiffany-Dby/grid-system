using System;
using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefabToSpawn;

    IEnumerator SpawnObjectOnInterval(bool condition, string name, int posX, int posY, int posZ, int seconds)
    {
        while (condition)
        {
            SpawnGameObject(name, posX, posY, posZ);
            yield return new WaitForSeconds(seconds);
        }
    }

    public void SpawnGameObject(string name, int posX, int posY, int posZ)
    {
        GameObject spawnedPrefab = Instantiate(prefabToSpawn);

        spawnedPrefab.transform.position = new Vector3(posX, posY, posZ);
        spawnedPrefab.name = name;
    }
}
