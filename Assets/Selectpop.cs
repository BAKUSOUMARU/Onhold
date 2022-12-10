using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectpop : MonoBehaviour
{
    [SerializeField]
    GameObject _title;

    [SerializeField]
    GameObject _select;

    void Start()
    {
        if (GameManager.Instance.IsSelect)
        {
            _title.SetActive(false);
            _select.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
