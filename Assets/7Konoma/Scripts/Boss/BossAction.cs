using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossAction : MonoBehaviour
{
    [SerializeField]
    [Header("ジャンプの高さ")]
    float _junpHeight;

    [SerializeField]
    [Header("突進時間")]
    int _lungesTime;

    [SerializeField]
    [Header("ジャンプした回数")]
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
        Debug.Log("ジャンプ");
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

