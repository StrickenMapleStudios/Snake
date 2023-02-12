using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private PlayerControls playerControls;

    private Vector2 _direction = Vector2.right;

    public Vector2 Direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Update()
    {
        Vector2 move = playerControls.Player.Move.ReadValue<Vector2>();

        if (Mathf.Round(move.x) - _direction.x != 0 && Mathf.Round(move.y) - _direction.y != 0)
        {
            if (Mathf.Abs(move.x) == Mathf.Abs(move.y))
            {
                _direction = new Vector2(Mathf.Round(move.x), 0);
            } else
            {
                _direction = move;
            }
        }
    }
}
