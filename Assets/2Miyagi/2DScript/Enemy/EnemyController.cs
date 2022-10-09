using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("��{�ݒ�"), Tooltip("��{�̑���")]
    [SerializeField]
    float _defaultSpeed = 5; //�ʏ푬�x

    Rigidbody2D rb;
    enum VerticalHorizontalChange
    {
        Vertical,
        Horizontal
    }//�ǂ��Ɉړ����邩��Enum(�c or ��)

    [Header("���]�ݒ�"), Tooltip("�ړ����� : �c / ��")]
    [SerializeField]
    VerticalHorizontalChange vhChange;

    enum TurnAround
    {
        Time,
        WallTouch,
        FloorContact
    }//�ǂ̂悤�ɔ��]���邩��Enum(���� or �ǂɓ��������� or ���ɐG��ĂȂ��Ƃ�)

    [Tooltip("���]���@ : ���� / �ǂɓ��������� / ���ɐG��ĂȂ��Ƃ�")]
    [SerializeField]
    TurnAround turnAround;

    [Tooltip("���]���@���u Time �v�̏ꍇ�� ���]����(s)")]
    [SerializeField]
    float _turnTime = 10;

    float _countTime = 0;//���]���@���u Time �v�̏ꍇ�ɓ����ϐ��@(������ƕς���Ύg��Ȃ��Ă�����)

    bool _wallTouch = false;//���]���@���u WallTouch �v�̏ꍇ��bool
    bool _floorContact = false;//���]���@���u FloorContact �v�̏ꍇ��bool

    [Tooltip("�ǂ����m���铖���蔻��")]
    [SerializeField]
    List<GameObject> _wallDetection = new List<GameObject>();

    [Tooltip("�������m���铖���蔻��")]
    [SerializeField]
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
        }//�ړ��ݒ�(�c or ��)

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
        }//���]�ݒ�(���� or �ǂɓ��������� or ���ɐG��ĂȂ��Ƃ�)
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
