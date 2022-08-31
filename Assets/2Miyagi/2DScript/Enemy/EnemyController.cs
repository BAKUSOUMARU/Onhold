using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("��{�ݒ�")]
    [SerializeField] 
    [Tooltip("��{�̑���")]
    float _defaultSpeed = 5;

    Rigidbody2D rb;
    enum VerticalHorizontalChange
    {
        Vertical,
        Horizontal
    }

    [Header("���]�ݒ�")]
    [SerializeField]
    [Tooltip("�ړ����� : �c / ��")]
    VerticalHorizontalChange vhChange;

    enum TurnAround
    {
        Time,
        WallTouch,
        FloorContact
    }

    [SerializeField]
    [Tooltip("���]���@ : ���� / �ǂɓ��������� / ���ɐG��ĂȂ��Ƃ�")]
    TurnAround turnAround;

    [SerializeField]
    [Tooltip("���]���@���uTime�v�̏ꍇ�� ���]����(s)")]
    float _turnTime = 10;

    float _countTime = 0;

    bool _wallTouch = false;
    bool _floorContact = false;

    [SerializeField]
    [Tooltip("�ǂ����m���铖���蔻��")]
    List<GameObject> _wallDetection = new List<GameObject>();

    [SerializeField]
    [Tooltip("�������m���铖���蔻��")]
    List<GameObject> _floorDetection = new List<GameObject>();
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        switch (vhChange)
        {
            case VerticalHorizontalChange.Horizontal:
                rb.velocity = new Vector2(_defaultSpeed,rb.velocity.y);
                break;
            case VerticalHorizontalChange.Vertical:
                rb.velocity = new Vector2(rb.velocity.x, _defaultSpeed);
                break;
        }

        switch (turnAround)
        {
            case TurnAround.Time:
                _countTime++;
                if(_turnTime * 60 <= _countTime)
                {
                    _defaultSpeed = _defaultSpeed * -1;
                    _countTime = 0;
                }
            break;

            case TurnAround.WallTouch:
                _wallTouch = true;
                for(int i =0; i < _wallDetection.Count ; i++)
                {
                    _wallDetection[i].gameObject.SetActive(true);
                }
            break;

            case TurnAround.FloorContact:
                _floorContact = true;
                for (int i = 0; i < _floorDetection.Count; i++)
                {
                    _floorDetection[i].gameObject.SetActive(true);
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (_wallTouch)
        {
            _defaultSpeed = _defaultSpeed * -1;   
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (_floorContact)
        {
            _defaultSpeed = _defaultSpeed * -1;
        }
    }
}
