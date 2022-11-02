using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class OxygenPresenter : MonoBehaviour
{
    [SerializeField]
    PlayerData _playerData;

    [SerializeField]
    OxygenView _oxygenView;

    private void Start()
    {
        _playerData.Oxygen.Subscribe(x => _oxygenView.SetOxygen(x)).AddTo(this);
    }
}
