using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Onhold.Scene;
public class PlayeDestroy : MonoBehaviour
{
    [SerializeField]int _sceneIndex = 8;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            GameOver();
            Debug.Log("“®‚¢‚½‚æ");
        }
    }

    public void GameOver()
    {
        SceneChange.NextScene(_sceneIndex);
    }
}
