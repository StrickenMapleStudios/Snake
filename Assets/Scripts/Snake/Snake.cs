using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private GameArea gameArea;
    private SnakeBody snakeBody;
    private SnakeBehaviour snakeBehaviour;

    private bool isCollisionLocated = false;
    public bool IsCollisionLocated
    {
        get { return isCollisionLocated; }
        set { isCollisionLocated = value; }
    }

    private bool isActive = false;
    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }

    private int _length;
    private int score = 0;

    public int Length
    {
        get { return _length; }
    }

    public int Score
    {
        get { return score; }
    }

    private void Awake()
    {
        gameArea = FindObjectOfType<GameArea>();
        snakeBody = GetComponent<SnakeBody>();
        snakeBehaviour = GetComponent<SnakeBehaviour>();
        _length = snakeBody.InitialSize;
        score = 0;
    }

    public void StartGame()
    {
        isActive = false;
        snakeBody.CreateBody();
        snakeBehaviour.Reset();
        score = 0;
        snakeBehaviour.enabled = true;
        //isActive = true;
    }

    public void CollisionDetected(Collider2D collider)
    {
        if (collider.tag == "Food")
        {
            snakeBody.Grow();
            IncreaseScore();
            gameArea.RefreshInfo(snakeBody.Body.Count, Score);
        } else if (collider.tag == "Wall" || collider.tag == "Player")
        {
            Die();
        }
    }

    public void CollisionLocated(Collider2D collider)
    {
        if (collider.tag != "Food")
        {
            isCollisionLocated = true;
        }
    }

    public void IncreaseScore()
    {
        score += 23;
    }

    public void Die()
    {
        //isActive = false;
        snakeBehaviour.enabled = false;
        gameArea.GameOver();
    }
}
