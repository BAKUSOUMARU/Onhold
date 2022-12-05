using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGunController : MonoBehaviour
{
    [SerializeField]
    PlayerData _playerData;


    [SerializeField] 
    float _timer = 3;

    float _resetTimer;
    
    bool isTimerStart = false;
    private void Awake()
    {
        _resetTimer = _timer; 
    }

    public void OnEnable()
    {
        isTimerStart = true;
    }
    

    void Update()
    {
        Timer();
    }

    void Timer()
    {
        if(_timer <= 0)
        {
            isTimerStart = false;
            _timer = _resetTimer;
            this.gameObject.SetActive(false);
            _playerData.FireGunOn() ;
        }
        else if (isTimerStart)
        {
            _timer -= Time.deltaTime; 
        }
    }
    

}
