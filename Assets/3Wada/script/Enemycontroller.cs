using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontroller : MonoBehaviour
{
    [SerializeField] float _speed = 5;
    Rigidbody2D _rd;


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
        _rd.velocity = Vector2.right * _speed;
    }

}
