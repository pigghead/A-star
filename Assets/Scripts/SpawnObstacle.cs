using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject obstacle;
    PathMaker PM;

    private int rand;
    
    void Start()
    {
        PM = GameObject.Find("GameManager").GetComponent<PathMaker>();

        Debug.Log("Adding obstacle spawner to list");
        PM.obstaclesSpawners.Add(this);

        SpawnNewObstacle();
    }

    public void SpawnNewObstacle()
    {
        rand = Random.Range(0, 101);

        if (rand % 2 == 0)
        {
            // WHY IS THIS BROKEN I DID NOT CHANGE SHIT 
            GameObject go = Instantiate(obstacle, transform.position, Quaternion.identity);

            if (go == null || PM == null)
                Debug.Log("I fucking hate it here");

            PM.obstacles.Add(go);
        }
    }
}
