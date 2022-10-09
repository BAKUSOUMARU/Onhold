using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("基本設定"), Tooltip("基本の速さ")]
    [SerializeField]
    float _defaultSpeed = 5; //通常速度

    Rigidbody2D rb;
    enum VerticalHorizontalChange
    {
        Vertical,
        Horizontal
    }//どこに移動するかのEnum(縦 or 横)

    [Header("反転設定"), Tooltip("移動方向 : 縦 / 横")]
    [SerializeField]
    VerticalHorizontalChange vhChange;

    enum TurnAround
    {
        Time,
        WallTouch,
        FloorContact
    }//どのように反転するかのEnum(時間 or 壁に当たった時 or 床に触れてないとき)

    [Tooltip("反転方法 : 時間 / 壁に当たった時 / 床に触れてないとき")]
    [SerializeField]
    TurnAround turnAround;

    [Tooltip("反転方法が「 Time 」の場合の 反転時間(s)")]
    [SerializeField]
    float _turnTime = 10;

    float _countTime = 0;//反転方法が「 Time 」の場合に動く変数　(ちょっと変えれば使わなくてもいい)

    bool _wallTouch = false;//反転方法が「 WallTouch 」の場合のbool
    bool _floorContact = false;//反転方法が「 FloorContact 」の場合のbool

    [Tooltip("壁を検知する当たり判定")]
    [SerializeField]
    List<GameObject> _wallDetection = new List<GameObject>();

    [Tooltip("床を検知する当たり判定")]
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
        }//移動設定(縦 or 横)

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
        }//反転設定(時間 or 壁に当たった時 or 床に触れてないとき)
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
