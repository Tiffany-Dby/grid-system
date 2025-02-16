using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefabToSpawn;

    public GameObject SpawnGameObject(string name, int posX, int posY, int posZ)
    {
        GameObject spawnedPrefab = Instantiate(prefabToSpawn);

        spawnedPrefab.transform.position = new Vector3(posX, posY, posZ);
        spawnedPrefab.name = name;

        return spawnedPrefab;
    }
}
