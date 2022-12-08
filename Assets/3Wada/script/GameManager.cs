using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public bool IsSelect => isSelect;

    int _score;

    public string retrysceneName = default;

    public string NextsceneName = default;

    bool isSelect = false;    
    public int Score => _score;

    int _reset = 0;

    public void ScoreUP(int score)
    {
        _score += score;
    }

    public void ScoreReset()
    {
        _score = _reset;
    }

    public void SelectOn()
    {
        isSelect = true;
    }
}
