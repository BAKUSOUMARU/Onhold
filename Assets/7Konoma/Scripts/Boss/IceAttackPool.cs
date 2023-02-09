using System.Collections.Generic;
using UnityEngine;

public class IceAttackPool : MonoBehaviour
{
    [SerializeField]
    List<GameObject> _iceAttackPool;

    [SerializeField]
    [Header("ïXÉvÉåÉnÉu")]
    private GameObject _iceObj;

    [SerializeField]
    [Header("ê∂ê¨Ç∑ÇÈïXÇÃêî")]
    int _createCount;

    void Awake()
    {
        CreatePool();
    } 
    
    private void CreatePool()
    {
        _iceAttackPool = new List<GameObject>();
        for (int i = 0; i < _createCount; i++)
        {
            var newObj = CreateIceAttack();
            newObj.GetComponent<Rigidbody2D>().simulated = false;
            _iceAttackPool.Add(newObj);
            newObj.SetActive(false);
        }
    }

    private GameObject CreateIceAttack()
    {
        var newObj = Instantiate(_iceObj, transform.position, transform.rotation);
        newObj.name = _iceObj.name + (_iceAttackPool.Count + 1);

        return newObj;
    }

    public GameObject GetIceAttack()
    {
        foreach (var IceAttack in _iceAttackPool)
        {
            if (!IceAttack.gameObject.activeSelf)
            {
                IceAttack.transform.position = transform.position;
                IceAttack.GetComponent<Rigidbody2D>().simulated = true;
                IceAttack.SetActive(true);
                return IceAttack;
            }
        }

        var newObj = CreateIceAttack();
        _iceAttackPool.Add(newObj);
        return newObj;
    }
}
