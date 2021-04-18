using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFinish : MonoBehaviour
{
    public GameObject EndObject;
    public PathMaker PM;

    private void Start()
    {
        PM = GameObject.Find("GameManager").GetComponent<PathMaker>();

        PM.finishSpawners.Add(this);
    }

    public void SpawnNewFinish()
    {
        GameObject go = Instantiate(EndObject, transform.position, Quaternion.identity);

        PM.AssignEndGameObject(go);
    }
}
