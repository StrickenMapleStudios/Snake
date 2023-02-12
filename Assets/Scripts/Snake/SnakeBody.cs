using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{

    private List<Transform> _body;

    public List<Transform> Body
    {
        get { return _body; }
    }

    [SerializeField]
    private Transform headPrefab, bodyPrefab;
    [SerializeField]
    private int initialSize = 3;

    public int InitialSize
    {
        get { return initialSize; }
    }

    private void Awake()
    {
        _body = new List<Transform>();
    }

    public void CreateBody()
    {
        if (_body.Count > 0)
        {
            DestroyBody();
        }

        Transform head = CreateObject(headPrefab);
        head.position = Vector2.zero - Vector2.right;
        _body.Add(head);

        for (int i = 1; i < initialSize; ++i)
        {
            Transform segment = CreateObject(bodyPrefab);
            segment.position = (Vector2)_body[i - 1].position - Vector2.right;
            _body.Add(segment);
        }
    }

    public void Grow()
    {
        Transform segment = CreateObject(bodyPrefab);
        segment.position = _body[_body.Count - 1].position;
        _body.Add(segment);
    }

    public Transform CreateObject(Transform prefab)
    {
        Transform obj = Instantiate(prefab);
        obj.SetParent(transform);
        return obj;
    }

    public void DestroyBody()
    {
        for (int i = 0; i < _body.Count; ++i)
        {
            Destroy(_body[i].gameObject);
        }
        _body.Clear();
    }
}
