using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    private Rigidbody2D rb;
    GameObject _light;

    [SerializeField]float _jumpForce = 2000.0f;      //�W�����v���ɉ������
    [SerializeField]float _runSpeed = 5.0f;         //�����Ă���Ԃ̑��x

    float horizontalKey;
    
    bool isGround = true;           //�n�ʂƐݒu���Ă��邩�Ǘ�����t���O
    bool isWall = false;             //
    bool wallJump = false;

    //string state;                 //�v���C���[�̏�ԊǗ��@//������ւ�͎g��Ȃ�����������Ă�������.�A�j���[�V�����ȂǗp
    //string prevState;             //�O�̏�Ԃ�ۑ�        //�g�p��:https://xr-hub.com/archives/8808
    //float _stateEffect = 1;          //�󋵂ɉ����ĉ��ړ����x��ς��邽�߂̌W��
    void Start()
    {
        GameManager.instance._hammer = 0;
        GameManager.instance._score = 0;
        this.rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        if (Input.GetKey(KeyCode.Mouse1)){
            if (_light.activeSelf){
                _light.SetActive(false);
            } else {
                _light.SetActive(true);
            }
        }


    }

    private void Move()
    {

        horizontalKey = Input.GetAxis("Horizontal");
        if (!wallJump)
        {
            //�E���͂ō������ɓ���
            if (horizontalKey > 0)
            {
                rb.velocity = new Vector2(_runSpeed, rb.velocity.y);
            }
            //�����͂ō������ɓ���
            else if (horizontalKey < 0)
            {
                rb.velocity = new Vector2(-_runSpeed, rb.velocity.y);
            }
            //�{�^����b���Ǝ~�܂�
            else
            {
                rb.velocity = new Vector2(0,rb.velocity.y);
            }
        }
        


        if (isGround){
            if (isWall)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.AddForce(new Vector2(-rb.velocity.x, 10f) * 125);
                    isGround = false;
                    isWall = false;
                    wallJump = true;
                    Coroutine coroutine = StartCoroutine("DelayMethod", 0.3f);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    this.rb.AddForce(transform.up * this._jumpForce);
                    isGround = false;
                    isWall = false;
                }
            }   
        }
    }

    private IEnumerator DelayMethod(float delayFrameCount)
    {
        yield return new WaitForSecondsRealtime(delayFrameCount);
        wallJump = false;
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
                if (!isGround && !isWall)
                {
                    isGround = true;
                    isWall = true;
                }
                rb.velocity = new Vector2(0, 1);
            }
        }
        else
        {
                isWall = false;
        }
    }
}
