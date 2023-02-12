using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private float top, left, bottom, right;

    public void Init(int width, int height)
    {
        top = height / 2;
        right = width / 2;
        bottom = -top;
        left = -right;
    }

    public void RandomizePosition()
    {
        float x = Random.Range(left, right);
        float y = Random.Range(bottom, top);

        this.transform.position = new Vector2(
            Mathf.Round(x), Mathf.Round(y));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        RandomizePosition();
    }
}
