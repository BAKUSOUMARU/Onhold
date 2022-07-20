using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammercontroller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            GameManager.instance._hammer++;
            Debug.Log(GameManager.instance._hammer);
        }   
    }
}
