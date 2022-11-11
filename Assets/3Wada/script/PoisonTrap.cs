using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonTrap: MonoBehaviour
{
    [SerializeField] GameObject _poisontrap;
    [SerializeField] float _addScale = 0.01f;
    [SerializeField] int _startTrap = 1;
    float _scalesize = 1;
    bool istrap= false;
    Transform _tr;
    // Start is called before the first frame update
    void Start()
    {
         _tr = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        if (istrap) 
        {  
            PoisonMove();
        }
    }
    
    public void PoisonMove()
    {
        this.transform.localScale =new Vector3(_scalesize, 6, 1);
        _scalesize += _addScale;
    }

    public void IstrapTure()
    {
        istrap = true;
    }

    public void IstrapFalse()
    {
        istrap = false;
    }
}
