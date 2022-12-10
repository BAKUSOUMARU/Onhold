using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectpop : SingletonMonoBehaviour<Selectpop>
{
    [SerializeField]
    GameObject _title;

    [SerializeField]
    GameObject _select;

    public void test()
    { 
        if (GameManager.Instance.IsSelect)
        {
            _title.SetActive(false);
            _select.SetActive(true);
            JsonStageSelect.Instance.Load();
        }
    }
}
