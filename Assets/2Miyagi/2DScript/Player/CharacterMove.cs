
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]GameObject _light;
    static public float _battery = 100;
    [SerializeField]Text batteryText;
    Animator _anim;

    [SerializeField]
    float _jumpForce = 1400.0f;      //ジャンプ時に加える力

    float _defaultJumpForce;

    [SerializeField]
    float _runSpeed = 8.0f;         //走っている間の速度

    [SerializeField]
    float _wallJumpCoolTime = 0.3f; //壁ジャンのクールタイム

    float horizontalKey;
    
    bool isGround = true;           //地面と設置しているか管理するフラグ
    bool isWall = false;             //
    bool wallJump = false;

    //string state;                 //プレイヤーの状態管理　//ここらへんは使わなかったら消してください.アニメーションなど用
    //string prevState;             //前の状態を保存        //使用例:https://xr-hub.com/archives/8808
    //float _stateEffect = 1;          //状況に応じて横移動速度を変えるための係数
    void Start()
    {
        GameManager.instance._hammer = 0;
        GameManager.instance._score = 0;
        this.rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _defaultJumpForce = _jumpForce;
    }

    private void Update()
    {
        Move();
        WaterPlayer();

        if (_light.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                _light.SetActive(false);
            }

            if(_battery <= 100)
            {
                _battery -= 0.01f;
                batteryText.text = string.Format("{0:000}%", _battery);
            }
            else if (_battery <= 0)
            {
                _light.SetActive(false);
            }
        }
        else if (!_light.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                _light.SetActive(true);
            }
        }
    }

    private void Move()
    {
        horizontalKey = Input.GetAxis("Horizontal");
        if (!wallJump)
        {
            //右入力で右向きに動く
            if (horizontalKey > 0)
            {
                rb.velocity = new Vector2(_runSpeed, rb.velocity.y);
                _anim.SetBool("Rightrun", true);
                _anim.SetBool("Leftrun", false);

            }
            //左入力で左向きに動く
            else if (horizontalKey < 0)
            {
                rb.velocity = new Vector2(-_runSpeed, rb.velocity.y);
                _anim.SetBool("Leftrun", true);
                _anim.SetBool("Rightrun", false);
            }
            //ボタンを離すととまる
            else
            {
                rb.velocity = new Vector2(0,rb.velocity.y);
                _anim.SetBool("Leftrun", false);
                _anim.SetBool("Rightrun", false);
            }
        }

        if (isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.rb.AddForce(transform.up * this._jumpForce);
                isGround = false;
            }
        }
        else if (!isGround)
        {
            if (isWall)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.AddForce(new Vector2(-rb.velocity.x, 10f) * 125);
                    isWall = false;
                    wallJump = true;
                    Coroutine coroutine = StartCoroutine("DelayMethod", _wallJumpCoolTime);
                }
            }
        }
    }

    private IEnumerator DelayMethod(float delayFrameCount)
    {
        yield return new WaitForSecondsRealtime(delayFrameCount);
        if(wallJump)wallJump = false;
        
    }
        private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy"){
            Destroy(col.gameObject);
            this.rb.AddForce(transform.up * this._jumpForce);
        }
        if(col.gameObject.tag == "Ground" || col.gameObject.tag == "DropGround")
        {
            if (!isGround)
                isGround = true;
        }
        if(col.gameObject.tag == "Water")
        {
            _boolOxygun = true;
            
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            if (!isGround)
                isGround = true;
        }
        if(col.gameObject.tag == "Wall")
        {
            if (horizontalKey > 0 || horizontalKey < 0)
            {
                if (!isWall)
                {
                    isWall = true;
                }
                rb.velocity = new Vector2(0, 0.5f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Wall")
        {
            if (isWall) { isWall = false; }
        }
        if(col.gameObject.tag == "Ground")
        {
            if(isGround) { isGround = false; }
        }
        if(col.gameObject.tag == "Water")
        {
            _boolOxygun = false;
        }
    }

    [SerializeField]
    float _oxygenCount = 100;

    [SerializeField]
    Text oxugenText;

    bool _boolOxygun;

    [SerializeField]
    float _defaultGravityScale = 8; //酸素上の重力

    [SerializeField]
    float _anoxiaGravityScale; //無酸素状態の重力

    [SerializeField]
    float _anoxiaJumpForce;
    void WaterPlayer()
    {
        if (_boolOxygun)
        {
            isGround = true;
            if(_oxygenCount >= 0)
            {
                _oxygenCount -= 0.05f;
                oxugenText.text = string.Format("{0:000}oxy",_oxygenCount);

                rb.gravityScale = _anoxiaGravityScale;
                _jumpForce = _anoxiaJumpForce;
                Coroutine coroutine = StartCoroutine("DelayMethod", _wallJumpCoolTime);
            }
            else if (_oxygenCount <= 0)
            {
                print("finish");
            }
        }
        else if (!_boolOxygun)
        {
            if(_oxygenCount <= 100)
            {
                _oxygenCount += 0.05f;
                oxugenText.text = string.Format("{0:000}oxy", _oxygenCount);

                rb.gravityScale = _defaultGravityScale;
                _jumpForce = _defaultJumpForce;
            }
        }
    }
}
