using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using OnholdEnums;

public class PlayeDestroy : MonoBehaviour
{
    [SerializeField] Scenes scenes;
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
        SceneManager.LoadScene(scenes.ToString()); 
    }
}
