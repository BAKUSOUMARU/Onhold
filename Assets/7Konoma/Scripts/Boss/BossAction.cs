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
    [Header("�W�����v������")]
    int _junpCount;

    [SerializeField]
    IceAttackPool _attackPool;

    [SerializeField]
    float _xPos;

    [SerializeField]
    Rigidbody2D _rb2;

    [SerializeField]
    Transform _tr;
    public void IceAtack()
    {
        var IceAttack = _attackPool.GetIceAttack();
        IceAttack.transform.position = gameObject.transform.position;
    }

    public void Update()
    {

    }

    public void Junp()
    {
        Debug.Log("�W�����v");
        _rb2.velocity = new Vector2(0, _junpHeight);
        _junpCount++;
    }

    public void  Lunges()
    {
        _junpCount = 0;
        _xPos = gameObject.transform.position.x -5;
        _tr.DOMoveX(_xPos,_lungesTime);
        Debug.Log(_xPos);
    }
}

