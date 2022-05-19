using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenFloor : MonoBehaviour
{
    bool fall;
    Rigidbody2D rb;
    private void Start()
    {
        fall = false;
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            fall = true;   
        } else if (col.gameObject.tag =="Ground"){
            //Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(fall == true)
        {
            //transform.Translate(0, -0.1f, 0);
            rb.velocity = new Vector2(0,-10);
        }
    }
}
