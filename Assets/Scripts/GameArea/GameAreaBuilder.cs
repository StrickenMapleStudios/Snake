using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAreaBuilder : MonoBehaviour
{
    [SerializeField]
    private int width = 31, height = 19;
    public int Width
    {
        get { return width; }
    }
    public int Height
    {
        get { return height; }
    }

    [SerializeField]
    private Transform wallsPrefab, snakePrefab, foodPrefab;

    private Walls walls;
    private Snake snake;
    private Food food;

    public Snake Snake
    {
        get { return snake; }
    }
    public Food Food
    {
        get { return food; }
    }

    private void Awake()
    {
        transform.localScale = new Vector2(width, height);
        walls = CreateObject(wallsPrefab).GetComponent<Walls>();
        snake = CreateObject(snakePrefab).GetComponent<Snake>();
        food = CreateObject(foodPrefab).GetComponent<Food>();
        walls.Init(Width - 2, Height - 2);
        food.Init(Width - 2, Height - 2);
    }
    private Transform CreateObject(Transform prefab)
    {
        Transform obj = Instantiate(prefab);

        obj.SetParent(transform);
        return obj;
    }
}
