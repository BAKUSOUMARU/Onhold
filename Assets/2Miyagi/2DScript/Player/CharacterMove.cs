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

    [SerializeField]GameObject _light;//light�̃I�u�W�F�N�g

    [SerializeField] private float jumpspeed =8f;
    Animator _anim;

    [SerializeField]
    float _jumpForce = 1400.0f;      //�W�����v���ɉ������

    float _defaultJumpForce;

    [SerializeField]
    float _runSpeed = 8.0f;         //�����Ă���Ԃ̑��x

    [SerializeField]
    float _wallJumpCoolTime = 0.3f; //�ǃW�����̃N�[���^�C��

    float horizontalKey;
    
    bool isGround = true;           //�n�ʂƐڂ��Ă��邩�Ǘ�����t���O
    bool isWall = false;            //�ǂɐڂ��Ă��邩�̃t���O
    bool wallJump = false;          //�ǃW������̒x���p

    [SerializeField]
    [Header("�Q�[���I�[�o�[�̃V�[��")]
    string GameOverScene;

    bool _boolOxygun;

    [SerializeField]
    float _defaultGravityScale = 8; //�_�f��̏d��

    [SerializeField]
    float _anoxiaGravityScale; //���_�f��Ԃ̏d��

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
    /// ���C�g�𑀍�
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
    /// ��{�I�ȓ����̑���
    /// </summary>
    private void Move()
    {
        horizontalKey = Input.GetAxis("Horizontal");

        Vector2 moveVector = new Vector2(8,1000);
        //velocity = velocity - rb.velocity;
        //velocity = new Vector2(Mathf.Clamp(velocity.x, -_runSpeed, _runSpeed),Mathf.Clamp(velocity.y,-jumpspeed, jumpspeed));
        if (!wallJump)
        {
            //�E���͂ŉE�����ɓ���
            if (horizontalKey > 0)
            {
                //rb.velocity = new Vector2(_runSpeed, rb.velocity.y);
                rb.AddForce(Vector2.right *(moveVector - rb.velocity), ForceMode2D.Force);
                _anim.SetBool("Rightrun", true);
                _anim.SetBool("Leftrun", false);

            }
            //�����͂ō������ɓ���
            else if (horizontalKey < 0)
            {
                //rb.velocity = new Vector2(-_runSpeed, rb.velocity.y);
                rb.AddForce(Vector2.left *(moveVector + rb.velocity), ForceMode2D.Force);
                _anim.SetBool("Leftrun", true);
                _anim.SetBool("Rightrun", false);
            }
            //�{�^���𗣂��ƂƂ܂�
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
        
    }//�ǃW�����̃f�B���C
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
    ///���ɓ����Ă鎞�̑��� 
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


