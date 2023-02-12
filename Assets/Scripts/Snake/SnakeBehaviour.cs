using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBehaviour : MonoBehaviour
{
    private Snake snake;
    private SnakeBody _snakeBody;
    private List<Transform> _body;
    private PlayerController controller;
    private Vector2 _direction = Vector2.right;

    public Vector2 Direction
    {
        get { return _direction; }
        set { _direction = controller.Direction = value; }
    }

    private void Awake()
    {
        snake = GetComponent<Snake>();
        _snakeBody = GetComponent<SnakeBody>();
        controller = GetComponent<PlayerController>();
        _body = _snakeBody.Body;
    }
    private void FixedUpdate()
    {
        if (_direction + controller.Direction != Vector2.zero)
        {
            _direction = controller.Direction;
        }

        for (int i = _body.Count - 1; i > 0; --i)
        {
            _body[i].position = _body[i - 1].position;
        }

        _body[0].position += (Vector3)_direction;
    }

    public void Reset()
    {
        _direction = controller.Direction = Vector2.right;
    }
}
