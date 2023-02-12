using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameArea : MonoBehaviour
{
    GameAreaBuilder gameAreaBuilder;

    [SerializeField]
    private GameplayCanvas canvas;

    private Snake snake;
    private Food food;

    private void Awake()
    {
        gameAreaBuilder = GetComponent<GameAreaBuilder>();
        snake = gameAreaBuilder.Snake;
        food = gameAreaBuilder.Food;
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        food.RandomizePosition();
        snake.StartGame();
        RefreshInfo(snake.Length, snake.Score);
    }

    public void RefreshInfo(int length, int score)
    {
        canvas.HUD.RefreshInfo(length, score);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        //canvas.GameOver.SetActive(true);
    }
}
