using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] grid;

    [HideInInspector]
    public bool debugDrawEnabled;

    private float debugDrawTime;

    public Grid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.grid = new int[width, height];

        debugDrawEnabled = false;
        debugDrawTime = 0f;

        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                CreateWorldText(grid[x,y].ToString(), GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * 0.5f, null, 12);
                //Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                //Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.black, 1000.0f);
            }
        }

        // Debug line along the top edge and the right edge
        //Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 1000.0f);
        //Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 1000.0f);
    }

    // multiple a given x and y coordinate with cell size to make a cell
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    // Set values within a specific grid
    public void SetValue(int x, int y, int targetValue)
    {
        grid[x, y] = targetValue;
    }

    public void ToggleDebugDraw()
    {
        if (debugDrawEnabled)
        {
            debugDrawEnabled = false;
            debugDrawTime = 0f;
        }
        else
        {
            debugDrawEnabled = true;
            debugDrawTime = 1000.0f;
        }

        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.black, debugDrawTime);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.black, debugDrawTime);
            }
        }

        // Debug line along the top edge and the right edge
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, debugDrawTime);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, debugDrawTime);
    }

    // Helper method for creating text in the world
    private TextMesh CreateWorldText(string text, Vector3 localPos, Transform parent, int fontSize, float characterSize = 0.14f)
    {
        GameObject g = new GameObject("Grid_Cell", typeof(TextMesh));
        Transform transform = g.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPos;
        TextMesh textMesh = g.GetComponent<TextMesh>();
        textMesh.fontSize = fontSize;
        textMesh.text = text;
        textMesh.characterSize = characterSize;
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.alignment = TextAlignment.Center;

        return textMesh;
    }
}
