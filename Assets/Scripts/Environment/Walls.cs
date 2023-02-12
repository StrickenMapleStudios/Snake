using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    private int top, left, bottom, right;
    [SerializeField]
    private Transform wallPrefab;

    public void Init(int width, int height)
    {
        top = height / 2 + 1;
        right = width / 2 + 1;
        bottom = -top;
        left = -right;
        CreateWalls();
    }

    private void CreateWalls()
    {
        for (float i = left; i <= right; i++)
        {
            CreateWall(i, bottom);
            CreateWall(i, top);
        }
        for (float i = bottom + 1; i <= top - 1; i++)
        {
            CreateWall(left, i);
            CreateWall(right, i);
        }
    }   

    private void CreateWall(float x, float y)
    {
        Transform wall = Instantiate(wallPrefab);
        wall.parent = transform;
        wall.position = new Vector3(x, y, transform.position.z);
    }
}
