using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    private Rigidbody2D rb;

    //public float _speed;
    float _jumpForce = 400.0f;      //�W�����v���ɉ������
    float _jumpThreshold = 2.0f;    //�W�����v�������肷�邽�߂�臒l
    float _runForce = 30.0f;        //���菉�߂ɉ������
    float _runSpeed = 0.5f;         //�����Ă���Ԃ̑��x
    float _runThreshold = 2.0f;     //���x�؂�ւ�����̂��߂�臒l
    public int _key = 0;                    //���E�̓��͊Ǘ�
    
    bool isGround = true;           //�n�ʂƐݒu���Ă��邩�Ǘ�����t���O 

    //string state;                 //�v���C���[�̏�ԊǗ��@//������ւ�͎g��Ȃ�����������Ă�������.�A�j���[�V�����ȂǗp
    //string prevState;             //�O�̏�Ԃ�ۑ�        //�g�p��:https://xr-hub.com/archives/8808
    float _stateEffect = 1;          //�󋵂ɉ����ĉ��ړ����x��ς��邽�߂̌W��
    void Start(){
        this.rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInputKey();
        Move();
    }

    private void Move()
    {
        float speedX = Mathf.Abs(this.rb.velocity.x);
        if (speedX < this._runThreshold)
        {
            this.rb.AddForce(transform.right * _key * this._runForce * _stateEffect);
        } else {
            this.transform.position += new Vector3(_runSpeed * Time.deltaTime * _key * _stateEffect, 0, 0);
        }


        if (isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.rb.AddForce(transform.up * this._jumpForce);
                isGround = false;
            }
        }

        
    }

    private void GetInputKey()
    {
        _key = 0;
        if (Input.GetKey(KeyCode.D))
            _key = 1;
        if (Input.GetKey(KeyCode.A))
            _key = -1;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ground")
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
    }
    // Update is called once per frame
    /*void FixedUpdate(){
        float horizontalKey = Input.GetAxis("Horizontal");
        if(horizontalKey > 0){
            //rb.velocity = new Vector2(speed, rb.velocity.y);
            rb.AddForce(transform.right * _speed);
        } else if (horizontalKey < 0){
            //rb.velocity = new Vector2(-speed, rb.velocity.y);
            rb.AddForce(-transform.right * _speed);
        } else{
            rb.velocity = Vector2.zero;
        }

        bool velocityKey = Input.GetKey(KeyCode.Space);
        if (velocityKey == true && isGround)
        {
            rb.AddForce(transform.up * 400.0f);
            isGround = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            if (!isGround) isGround = true;
        }
    }*/
}
