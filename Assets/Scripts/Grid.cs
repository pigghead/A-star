using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] grid;

    public Grid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.grid = new int[width, height];

        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                CreateWorldText(grid[x,y].ToString(), GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * 0.5f, null, 12);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 1000.0f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 1000.0f);
            }
        }

        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 1000.0f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 1000.0f);
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    public void SetValue(int x, int y, int targetValue)
    {
        grid[x, y] = targetValue;
    }

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
