using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTesting : MonoBehaviour
{
    Camera cam;
    private Grid grid;

    void Start()
    {
        cam = Camera.main;
        grid = new Grid(4, 4, 1f);
    }

    public void ToggleDebugDraw()
    {
        grid.ToggleDebugDraw();
    }
}
