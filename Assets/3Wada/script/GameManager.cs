using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int _score;

    public string retrysceneName = default;

    public string NextsceneName = default;

    public static GameManager instance;
    
    public int Score => _score;

    int _reset = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void ScoreUP(int score)
    {
        _score += score;
    }

    public void ScoreReset()
    {
        _score = _reset;
    }
}
