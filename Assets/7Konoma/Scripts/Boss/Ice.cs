using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    [SerializeField]
    [Header("飛ぶスピード")]
    float _speed;

    [Header("経過時間")]
    float _count;

    [SerializeField]
    [Header("氷の持続時間")]
    int _timer;

    void FixedUpdate()
    {
        transform.Translate(-_speed, 0, 0);

        _count++;

        if (_timer <= _count)
        {
            gameObject.SetActive(false);
            _count = 0;
        }
    }
}
