using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeLocator : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponentInParent<Snake>().CollisionLocated(collision);
        Debug.Log("Locator detected " + collision.name);
        Destroy(gameObject);
    }
}
