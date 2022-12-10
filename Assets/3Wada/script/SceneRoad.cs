using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRoad : MonoBehaviour
{
    [SerializeField] SceneChange _sceneChange;

    [SerializeField] int _stageIndex;

    [SerializeField] GameObject _stageCanvas;
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
            case SceneChange.Stage:
                _stageCanvas.SetActive(false);
                SceneManager.LoadScene("Stage"+_stageIndex);
                break;
        }

    }

    enum SceneChange
    {
        retry,
        Select,
        Stage
    }
}
