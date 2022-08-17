using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreitem : MonoBehaviour
{
    public int _plusScore = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            GameManager.instance._score+=_plusScore;
            Debug.Log(GameManager.instance._score);
        }
    }
}
