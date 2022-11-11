using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Onhold.Scene;
public class CharacterMove : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    private Rigidbody2D rb;

    [SerializeField] 
    PoisonTrap _poisontrap;

    [SerializeField]GameObject _light;//lightのオブジェクト

    [SerializeField] private float jumpspeed =8f;
    Animator _anim;

    [SerializeField]
    float _jumpForce = 1400.0f;      //ジャンプ時に加える力

    float _defaultJumpForce;

    [SerializeField]
    float _runSpeed = 8.0f;         //走っている間の速度

    [SerializeField]
    float _wallJumpCoolTime = 0.3f; //壁ジャンのクールタイム

    float horizontalKey;
    
    bool isGround = true;           //地面と接しているか管理するフラグ
    bool isWall = false;            //壁に接しているかのフラグ
    bool wallJump = false;          //壁ジャン後の遅延用

    [SerializeField]
    [Header("ゲームオーバーのシーン")]
    string GameOverScene;

    bool _boolOxygun;

    [SerializeField]
    float _defaultGravityScale = 8; //酸素上の重力

    [SerializeField]
    float _anoxiaGravityScale; //無酸素状態の重力

    [SerializeField]
    float _anoxiaJumpForce;
    void Start()
    {
        GameManager.instance.ScoreReset();
        this.rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _defaultJumpForce = _jumpForce;
    }

    private void Update()
    {    
        Move();
        WaterPlayer();
        LightMove();
    }
    
        
    

    /// <summary>
    /// ライトを操作
    /// </summary>
    private void LightMove()
    {
        if (_light.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                _light.SetActive(false);
            }

            if (_playerData.Battery.Value >= 0)
            {
                _playerData.BatteryReduce();
            }
            else if (_playerData.Battery.Value <= 0)
            {
                _light.SetActive(false);
            }
        }
        else if (!_light.activeSelf && _playerData.Battery.Value <= 100)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                _light.SetActive(true);
            }
        }
    }

    /// <summary>
    /// 基本的な動きの操作
    /// </summary>
    private void Move()
    {
        horizontalKey = Input.GetAxis("Horizontal");

        Vector2 moveVector = new Vector2(8,1000);
        //velocity = velocity - rb.velocity;
        //velocity = new Vector2(Mathf.Clamp(velocity.x, -_runSpeed, _runSpeed),Mathf.Clamp(velocity.y,-jumpspeed, jumpspeed));
        if (!wallJump)
        {
            //右入力で右向きに動く
            if (horizontalKey > 0)
            {
                //rb.velocity = new Vector2(_runSpeed, rb.velocity.y);
                rb.AddForce(Vector2.right *(moveVector - rb.velocity), ForceMode2D.Force);
                _anim.SetBool("Rightrun", true);
                _anim.SetBool("Leftrun", false);

            }
            //左入力で左向きに動く
            else if (horizontalKey < 0)
            {
                //rb.velocity = new Vector2(-_runSpeed, rb.velocity.y);
                rb.AddForce(Vector2.left *(moveVector + rb.velocity), ForceMode2D.Force);
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

                rb.AddForce(Vector2.up * (moveVector + rb.velocity), ForceMode2D.Force);     
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
                    Coroutine coroutine = StartCoroutine("WallDelay", _wallJumpCoolTime);
                }
            }
        }
    }

    private IEnumerator WallDelay(float delayFrameCount)
    {
        yield return new WaitForSecondsRealtime(delayFrameCount);
        if(wallJump)wallJump = false;
        if (isGround) isGround = false;
        
    }//壁ジャンのディレイ
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
        if (col.gameObject.tag == "Battery")
        {
            _playerData.BatteryHeel();
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Hammer")
        {
            _playerData.HammerUP();
            Destroy(col.gameObject);
            _poisontrap.IstrapTure();
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
            isGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "HammerWall")
        {
            if (_playerData.Hammer.Value == 0)
            {
                return;
            }
            else
            {
                _playerData.HammerDown();
                Destroy(collision.gameObject);
                
            }
        }
    }

    /// <summary>
    ///水に入ってる時の操作 
    /// </summary>
    void WaterPlayer()
    {
        if (_boolOxygun)
        {
            isGround = true;
            if(_playerData.Oxygen.Value >= 0)
            {
                _playerData.OxygenDown();
                

                rb.gravityScale = _anoxiaGravityScale;
                _jumpForce = _anoxiaJumpForce;
            }
            else if (_playerData.Oxygen.Value <= 0)
            {
                SceneChange.NextScene(8);
            }
        }
        else if (!_boolOxygun)
        {
            if(_playerData.Oxygen.Value <= 100)
            {
                _playerData.OxygenUp();
                rb.gravityScale = _defaultGravityScale;
                _jumpForce = _defaultJumpForce;
            }
        }
    }

  
}


