using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryView : MonoBehaviour
{
    [SerializeField] Text batteryText;//�o�b�e���[�e�L�X�g

    public void SetBattery(float battery)
    {
        batteryText.text = string.Format("{0:000}%", battery);
    }
}
