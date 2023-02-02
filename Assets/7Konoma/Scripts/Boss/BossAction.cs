using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossAction : MonoBehaviour
{
    [SerializeField]
    [Header("�W�����v�̍���")]
    float _junpHeight;

    [SerializeField]
    [Header("�ːi����")]
    int _lungesTime;

    [SerializeField]
    [Header("�W�����v�̉�")]
    int _junpCount;

    [SerializeField]
    [Header("�{�X��Rigidbody2D")]
    Rigidbody2D _rb2;

    [SerializeField]
    [Header("�{�X��transform")]
    Transform _tr;

    [SerializeField]
    [Header("�v���C���[��transform")]
    Transform _playerTr;

    [SerializeField]
    [Header("�{�X�̈ړ��X�s�[�h")]
    float _speed;

    [SerializeField]
    [Header("�s���̎���")]
    float[] _count;


    [SerializeField]
    private IceAttackPool _attackPool;

    [SerializeField]
    private float _xPos;

    private float _timer;
    private void Start()
    {
       _tr = gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        float dis = Vector2.Distance(_tr.position, _playerTr.transform.position);

        _timer++;
        if(dis > 20)
        {
            if (_count[0] < _timer)
            {
                _timer = 0;
                IceAtack();
            }
        }
        else if (dis >10)
        {
            _tr.position = Vector2.MoveTowards(_tr.position, new Vector2(_playerTr.position.x, _tr.position.y), _speed);
        }
        else if (dis > 5)
        {
            if (_count[1] < _timer && _junpCount > 1)
            {
                _timer = 0;
                _junpCount = 0;
                Lunges();
            }
            else if(_count[1] < _timer )
            {
                _timer = 0;
                _junpCount++;
                Junp();
            }
        }
    }

    public void IceAtack()
    {
        var IceAttack = _attackPool.GetIceAttack();
        IceAttack.transform.position = gameObject.transform.position;
    }

    public void Junp()
    {
        Debug.Log("�W�����v");
        _rb2.velocity = new Vector2(0, _junpHeight);
    }

    public void  Lunges()
    {
        if (_playerTr.position.x > _tr.position.x) _xPos = gameObject.transform.position.x + 5;
        else if (_playerTr.position.x < _tr.position.x) _xPos = gameObject.transform.position.x - 5;
        _tr.DOMoveX(_xPos,_lungesTime);
    }
}

