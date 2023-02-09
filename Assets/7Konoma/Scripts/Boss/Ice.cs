using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    [SerializeField]
    [Header("��ԃX�s�[�h")]
    float _speed;

    [Header("�o�ߎ���")]
    float _count;

    [SerializeField]
    [Header("�X�̎�������")]
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
