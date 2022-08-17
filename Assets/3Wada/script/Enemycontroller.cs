using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontroller : MonoBehaviour
{
    [SerializeField] float _speed = 5;
    Rigidbody2D _rd;
    [SerializeField] bool isEnemyMoveleft;

    void Start()
    {
        _rd = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        EnemyMove();
    }

    public void EnemyMove()
    {
        if (isEnemyMoveleft)
        {
            _rd.velocity = Vector2.left * _speed;    
        }
        else
        {
            _rd.velocity = Vector2.right * _speed;
        }
         
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            if (isEnemyMoveleft)
            {
                isEnemyMoveleft = false;
            }
            else if (!isEnemyMoveleft)
            {
                isEnemyMoveleft = true;
            }
        }
    }
}
