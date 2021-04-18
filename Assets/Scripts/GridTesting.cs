using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTesting : MonoBehaviour
{
    Camera cam;

    void Start()
    {
        cam = Camera.main;
        Grid grid = new Grid(4, 4, 1f);
    }
}
