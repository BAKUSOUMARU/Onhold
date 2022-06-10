using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenFloor : MonoBehaviour
{
    bool fall;
    Rigidbody2D rb;
    public bool fall_true;
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
        }
    }

    private void Update()
    {
        if(fall == true)
        {
            Coroutine coroutine = StartCoroutine("DelayMethod",0.5f);
        }
    }

    private IEnumerator DelayMethod(float delayFrameCount)
    {
        yield return new WaitForSecondsRealtime(delayFrameCount);

        if(fall_true == true)
        {
            Fallen();
        }
        else
        {
            Break();
        }
        
    }
    public void Fallen()
    {
        rb.velocity = new Vector2(0,-10);
        Destroy(gameObject, 0.5f);
    }
    public void Break()
    {
        Destroy(gameObject,0.5f);
    }
}
