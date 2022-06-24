using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeDestroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Debug.Log("“®‚¢‚½‚æ");
        }
    }
}
