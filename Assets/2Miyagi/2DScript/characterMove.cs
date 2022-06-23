using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    private Rigidbody2D rb;
    GameObject _light;

    [SerializeField]float _jumpForce = 2000.0f;      //�W�����v���ɉ������
    [SerializeField]float _runSpeed = 5.0f;         //�����Ă���Ԃ̑��x
    
    bool isGround = true;           //�n�ʂƐݒu���Ă��邩�Ǘ�����t���O
    bool isWall = false;             //

    //string state;                 //�v���C���[�̏�ԊǗ��@//������ւ�͎g��Ȃ�����������Ă�������.�A�j���[�V�����ȂǗp
    //string prevState;             //�O�̏�Ԃ�ۑ�        //�g�p��:https://xr-hub.com/archives/8808
    //float _stateEffect = 1;          //�󋵂ɉ����ĉ��ړ����x��ς��邽�߂̌W��
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


        if (isGround){
            if (isWall)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.AddForce(new Vector2(-rb.velocity.x, 2) * 400);
                    isGround = false;
                    isWall = false;
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

    private void OnTriggerEnter2D(Collider2D col)
    {
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
            if (!isGround && !isWall)
                isGround = true;
                isWall = true;
        }
        else
        {
            if (isWall)
                isWall = false;
        }
    }

    /*private void OnCollisionEnter2D(Collision2D col){
        
    }*/

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy"){
            Destroy(col.gameObject);
        }
    }
}
