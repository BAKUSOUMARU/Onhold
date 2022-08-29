using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Šî–{İ’è")]
    [SerializeField] 
    [Tooltip("Šî–{‚Ì‘¬‚³")]
    float _defaultSpeed = 5;

    Rigidbody2D rb;
    enum VerticalHorizontalChange
    {
        Vertical,
        Horizontal
    }

    [Header("”½“]İ’è")]
    [SerializeField]
    [Tooltip("ˆÚ“®•ûŒü : c / ‰¡")]
    VerticalHorizontalChange vhChange;

    enum TurnAround
    {
        Time,
        WallTouch,
        FloorContact
    }

    [SerializeField]
    [Tooltip("”½“]•û–@ : ŠÔ / •Ç‚É“–‚½‚Á‚½ / °‚ÉG‚ê‚Ä‚È‚¢‚Æ‚«")]
    TurnAround turnAround;

    [SerializeField]
    [Tooltip("”½“]•û–@‚ªuTimev‚Ìê‡‚Ì ”½“]ŠÔ(s)")]
    float _turnTime = 10;

    float _countTime = 0;

    bool _wallTouch = false;
    bool _floorContact = false;

    [SerializeField]
    [Tooltip("•Ç‚ğŒŸ’m‚·‚é“–‚½‚è”»’è")]
    List<GameObject> _wallDetection = new List<GameObject>();

    [SerializeField]
    [Tooltip("°‚ğŒŸ’m‚·‚é“–‚½‚è”»’è")]
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
