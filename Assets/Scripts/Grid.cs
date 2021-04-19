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

    // ctor defining the # of cells in x and y (width, height) and cellSize in float
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
            }
        }
    }

    /// <summary>
    /// Get a specific position in the world with respect to cell size
    /// </summary>
    /// <param name="x">x or width location of world position</param>
    /// <param name="y">y or height location of world position</param>
    /// <returns>Vector3 of (x, y, 0)</returns>
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    /// <summary>
    /// Set values within a specific cell in the grid
    /// </summary>
    /// <param name="x">The x value in grid[x,y]</param>
    /// <param name="y">The y value in grid[x,y]</param>
    /// <param name="targetValue">Value to set in our targeted cell</param>
    public void SetValue(int x, int y, int targetValue)
    {
        grid[x, y] = targetValue;
    }

    /// <summary>
    /// Allow us to toggle the lines to see the grid on screen
    /// </summary>
    public void DebugDraw()
    {
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                // Debug draw all lines aside from the upper width and right most height
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.black, debugDrawTime);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.black, debugDrawTime);
            }
        }

        // Debug line along the top edge and the right edge
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, debugDrawTime);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, debugDrawTime);
    }

    /// <summary>
    /// Allow us to create text in the world, on the fly
    /// </summary>
    /// <param name="text">What the text will say</param>
    /// <param name="localPos">Where the text will be created</param>
    /// <param name="parent">The TextMesh's parent in the hierarchy</param>
    /// <param name="fontSize">Size of the text</param>
    /// <param name="characterSize">Size of each character</param>
    /// <returns>TextMesh object</returns>
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
