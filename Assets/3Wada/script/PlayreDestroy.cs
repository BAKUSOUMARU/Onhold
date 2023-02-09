using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Onhold.Scene;
public class PlayreDestroy : MonoBehaviour
{
    [SerializeField] int _nowSceneNumber; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            GameOver(_nowSceneNumber);
            Debug.Log("“®‚¢‚½‚æ");
        }
    }

    public static void GameOver(int stageNumber)
    {
        GameManager.Instance.retrysceneName = "Stage" + stageNumber;
        SceneChange.GameOverScene();
    }
}
