using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRoad : MonoBehaviour
{
    [SerializeField] SceneChange _sceneChange;
   public void  Sceneroad()
    {
        switch (_sceneChange)
        {
            case SceneChange.Select:
                SceneManager.LoadScene("GameSelect");
                break;
            case SceneChange.retry:
                SceneManager.LoadScene(GameManager.Instance.retrysceneName);
                break;

        }

    }

    enum SceneChange
    {
        retry,
        Select
    }
}
