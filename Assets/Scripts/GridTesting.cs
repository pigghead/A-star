using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTesting : MonoBehaviour
{
    Camera cam;
    private Grid grid;

    [HideInInspector]
    public bool toggleDebug = false;

    void Start()
    {
        cam = Camera.main;
        grid = new Grid(4, 4, 1f);
    }

    void Update()
    {
        if (toggleDebug)
        {
            grid.DebugDraw();
        }
    }

    public void ToggleDebugDraw()
    {
        toggleDebug = !toggleDebug;
    }
}
