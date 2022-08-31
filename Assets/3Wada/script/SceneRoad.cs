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
            case SceneChange.Next:
                SceneManager.LoadScene(GameManager.instance.NextsceneName);
                break;
            case SceneChange.retry:
                SceneManager.LoadScene(GameManager.instance.retrysceneName);
                break;

        }

    }

    enum SceneChange
    {
        retry,
        Next
    }
}
