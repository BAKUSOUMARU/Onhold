using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryView : MonoBehaviour
{
    [SerializeField] Image _batteryImege;

    [SerializeField] Sprite[] _batterySprite;



    public void SetBattery(float battery)
    {
        if (battery < 0)
        {
            _batteryImege.sprite = _batterySprite[3];
        }
        else if (battery <30)
        {
            _batteryImege.sprite = _batterySprite[2];
        }
        else if (battery < 50)
        {
            _batteryImege.sprite = _batterySprite[1];
        }
        else if (battery >= 50)
        {
            _batteryImege.sprite = _batterySprite[0];
        }
        
    }
}
