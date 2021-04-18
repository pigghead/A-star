using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStart : MonoBehaviour
{
    public GameObject StartObject;
    public PathMaker PM;

    private void Start()
    {
        PM = GameObject.Find("GameManager").GetComponent<PathMaker>();

        PM.startSpawners.Add(this);
    }

    public void SpawnNewStart()
    {
        GameObject go = Instantiate(StartObject, transform.position, Quaternion.identity);

        PM.AssignStartGameObject(go);
    }
}
