using UnityEngine;

public class GenerateGame : MonoBehaviour
{
    public Spawn spawn;
    public GameObject groundPrefab;
    public GameObject wallPrefab;
    public GameObject boxPrefab;
    public GameObject goalPrefab;
    public GameObject playerPrefab;

    /*
    Level design pattern
        0 = Nothing (Empty)
        1 = Ground
        2 = Wall
        3 = Box
        4 = Goal
        5 = Player
    */
    int[,] levelMap = {
        {2, 2, 2, 2, 2, 2, 2},
        {2, 1, 2, 4, 1, 1, 2},
        {2, 1, 3, 1, 1, 1, 2},
        {2, 1, 1, 2, 3, 1, 2},
        {2, 1, 1, 1, 1, 1, 2},
        {2, 4, 2, 1, 1, 5, 2},
        {2, 2, 2, 2, 2, 2, 2}
    };

    void Start()
    {
        GenerateGameLevel();
    }

    void GenerateGameLevel()
    {
        if (spawn == null || groundPrefab == null || wallPrefab == null || goalPrefab == null || boxPrefab == null)
        {
            Debug.LogError("Spawn or Prefabs not assigned!");
            return;
        }

        int LEVEL_WIDTH = levelMap.GetLength(0);
        int LEVEL_HEIGHT = levelMap.GetLength(1);

        for (int x = 0; x < LEVEL_WIDTH; x++)
        {
            for (int y = 0; y < LEVEL_HEIGHT; y++)
            {
                int prefabType = levelMap[x, y];

                switch (prefabType)
                {
                    case 0: // Empty (skip)
                        break;

                    case 1: // Ground
                        spawn.prefabToSpawn = groundPrefab;
                        spawn.SpawnGameObject($"Ground_{x}_{y}", x, 0, y);
                        break;

                    case 2: // Wall (+ Ground)
                        spawn.prefabToSpawn = wallPrefab;
                        spawn.SpawnGameObject($"Wall_{x}_{y}", x, 1, y);
                        spawn.prefabToSpawn = groundPrefab;
                        spawn.SpawnGameObject($"Ground_{x}_{y}", x, 0, y);
                        break;

                    case 3: // Box (+ Ground)
                        spawn.prefabToSpawn = boxPrefab;
                        spawn.SpawnGameObject($"Box_{x}_{y}", x, 1, y);
                        spawn.prefabToSpawn = groundPrefab;
                        spawn.SpawnGameObject($"Ground_{x}_{y}", x, 0, y);
                        break;

                    case 4: // Goal
                        spawn.prefabToSpawn = goalPrefab;
                        spawn.SpawnGameObject($"Goal_{x}_{y}", x, 0, y);
                        break;

                    case 5: // Player (+ Ground)
                        spawn.prefabToSpawn = playerPrefab;
                        spawn.SpawnGameObject($"Box_{x}_{y}", x, 1, y);
                        spawn.prefabToSpawn = groundPrefab;
                        spawn.SpawnGameObject($"Ground_{x}_{y}", x, 0, y);
                        break;

                    default:
                        Debug.LogError($"Unknown prefab type {prefabType} at ({x}, {y})");
                        break;
                }
            }
        }
    }
}
