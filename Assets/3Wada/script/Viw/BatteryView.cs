using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryView : MonoBehaviour
{
    [SerializeField] Text batteryText;//バッテリーテキスト

    public void SetBattery(float battery)
    {
        batteryText.text = string.Format("{0:000}%", battery);
    }
}
