using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poisontrap : MonoBehaviour
{
    [SerializeField] GameObject _poisontrap;
    [SerializeField] float _addScale = 0.01f;
    float _scalesize = 1;
    Transform _tr;
    // Start is called before the first frame update
    void Start()
    {
         _tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        PoisonMove();    
    }
    
    public void PoisonMove()
    {
        this.transform.localScale =new Vector3(_scalesize, 1, 1);
        _scalesize += _addScale;
    }
}
