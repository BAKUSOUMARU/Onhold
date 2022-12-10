using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAction : MonoBehaviour
{
    float _attackTimer;
    float _attackWait;

    BossPattern _action;

    private void Awake()
    {
        _action = BossPattern.Stop;
        IceAttack();
    }

    private void FixedUpdate()
    {
        if (_attackTimer > _attackWait)
        {
           
          
        }
    }

    private void IceAttack()
    {
        var number = new System.Random();
        for (int i = 0; i > 4; i++)
        {
            Console.WriteLine((BossPattern)number.Next(sizeof(BossPattern)));
            Debug.Log(number);
        }
    }
}
