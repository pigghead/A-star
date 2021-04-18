using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMaker : MonoBehaviour
{
    public List<GameObject> obstacles;              // Currently spawned obstacles
    public List<SpawnObstacle> obstaclesSpawners;   // the positions to spawn obstacles at
    public List<SpawnStart> startSpawners;          // the positions to spawn start at (only 1)
    public List<SpawnFinish> finishSpawners;        // the positions to spawn finish at (only 1)

    private GameObject LocalStartSpawnPos;
    private GameObject LocalFinishSpawnPos;

    void Start()
    {
        //obstacles = new List<GameObject>();
        //obstaclesSpawners = new List<SpawnObstacle>();

        SpawnNewStart();
        SpawnNewFinish();
    }
    
    // Re-roll our obstacles
    public void Reroll()
    {
        // Reset the list and destroy all spawned walls
        for (int i = obstacles.Count-1; i > -1; i--)
        {
            //Debug.Log("Destroying obstacle...");
            Destroy(obstacles[i]);
            obstacles.RemoveAt(i);
        }

        // Remake our dungeon
        foreach (SpawnObstacle spawner in obstaclesSpawners)
        {
            spawner.SpawnNewObstacle();
        }

        // Replace a new start
        Destroy(LocalStartSpawnPos);
        SpawnNewStart();

        // Replace new finish
        Destroy(LocalFinishSpawnPos);
        SpawnNewFinish();
    }

    public void SpawnNewStart()
    {
        // Spawn one of the Start positions randomly
        int rand = Random.Range(0, startSpawners.Count);

        // Reference the specific startSpawner and instantiate it
        startSpawners[rand].SpawnNewStart();
    }

    public void AssignStartGameObject(GameObject ss)
    {
        LocalStartSpawnPos = ss;
    }

    public void SpawnNewFinish()
    {
        // Spawn one of the Start positions randomly
        int rand = Random.Range(0, finishSpawners.Count);

        // Reference specific finishSpawner and spawn it
        finishSpawners[rand].SpawnNewFinish();
    }

    public void AssignEndGameObject(GameObject fs)
    {
        LocalFinishSpawnPos = fs;
    }
}
