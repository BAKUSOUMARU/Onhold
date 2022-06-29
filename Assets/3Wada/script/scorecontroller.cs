using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scorecontroller : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    // Start is called before the first frame update
    void Start()
    {
        ResultScore();
    }

    void ResultScore()
    {
        _scoreText.text = "Score :" + GameManager.instance._score.ToString();   
    }
}
