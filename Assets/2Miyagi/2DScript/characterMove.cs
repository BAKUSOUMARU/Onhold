using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    private Rigidbody2D rb;
    GameObject _light;

    float _jumpForce = 400.0f;      //ジャンプ時に加える力
    float _runSpeed = 5.0f;         //走っている間の速度
    
    bool isGround = true;           //地面と設置しているか管理するフラグ 

    //string state;                 //プレイヤーの状態管理　//ここらへんは使わなかったら消してください.アニメーションなど用
    //string prevState;             //前の状態を保存        //使用例:https://xr-hub.com/archives/8808
    //float _stateEffect = 1;          //状況に応じて横移動速度を変えるための係数
    void Start(){
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

        float horizontalKey = Input.GetAxis("Horizontal");

        //右入力で左向きに動く
        if (horizontalKey > 0)
        {
            rb.velocity = new Vector2(_runSpeed, rb.velocity.y);
        }
        //左入力で左向きに動く
        else if (horizontalKey < 0)
        {
            rb.velocity = new Vector2(-_runSpeed, rb.velocity.y);
        }
        //ボタンを話すと止まる
        else
        {
            rb.velocity = new Vector2(0,rb.velocity.y);
        }


        if (isGround){
            if (Input.GetKeyDown(KeyCode.Space)){
                this.rb.AddForce(transform.up * this._jumpForce);
                isGround = false;
            }
        }

        
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

    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Enemy"){
            Destroy(col.gameObject);
        }
    }
}
