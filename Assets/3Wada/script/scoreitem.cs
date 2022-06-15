using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreitem : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            GameManager.instance._score++;
        }
    }
}
