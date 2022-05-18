using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    private Rigidbody2D rb;

    //public float _speed;
    float _jumpForce = 400.0f;      //ジャンプ時に加える力
    float _jumpThreshold = 2.0f;    //ジャンプ中か判定するための閾値
    float _runForce = 30.0f;        //走り初めに加える力
    float _runSpeed = 0.5f;         //走っている間の速度
    float _runThreshold = 2.0f;     //速度切り替え判定のための閾値
    public int _key = 0;                    //左右の入力管理
    
    bool isGround = true;           //地面と設置しているか管理するフラグ 

    //string state;                 //プレイヤーの状態管理　//ここらへんは使わなかったら消してください.アニメーションなど用
    //string prevState;             //前の状態を保存        //使用例:https://xr-hub.com/archives/8808
    float _stateEffect = 1;          //状況に応じて横移動速度を変えるための係数
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
