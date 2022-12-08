using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRoad : MonoBehaviour
{
    [SerializeField] 
    GameObject _title;

    [SerializeField]
    GameObject _gameSelect;
    
    public void RoadSelect()
    {
        _title.SetActive(false);
        _gameSelect.SetActive(true);
        GameManager.Instance.SelectOn();
        JsonStageSelect.Instance.Load();
    }
}
