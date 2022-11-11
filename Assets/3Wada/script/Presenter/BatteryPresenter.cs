using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BatteryPresenter : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] BatteryView _batteryView;

    private void Start()
    {
        _playerData.Battery.Subscribe(x => _batteryView.SetBattery(x)).AddTo(this);
    }
}
