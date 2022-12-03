using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerData : MonoBehaviour
{
    public FloatReactiveProperty Battery = new FloatReactiveProperty(100);

    public FloatReactiveProperty Oxygen = new FloatReactiveProperty(100);

    public IntReactiveProperty Hammer = new IntReactiveProperty(0);

    public IntReactiveProperty LIfe = new IntReactiveProperty(3);

    public int _fireGun = 0;

    public bool IsFireGun => isFireGun;

    bool isFireGun = true;

    public void BatteryHeel()
    {
        if (Battery.Value <= 80)
        {
            Battery.Value += 20;
        }
        else if (Battery.Value <= 100)
        {
            Battery.Value += 100 - Battery.Value;
        }
    }

    public void BatteryReduce()
    {
        Battery.Value -= 0.01f;
    }

    public void OxygenUp()
    {
        Oxygen.Value += 0.05f;
    }

    public void OxygenDown()
    {
        Oxygen.Value -= 0.05f;
    }

    public void HammerUP()
    {
        Hammer.Value ++;
    }

    public void HammerDown()
    {
        Hammer.Value --;
    }

    public void FireGunUP()
    {
        _fireGun++;
    }

    public void FireGunDown()
    {
        _fireGun--;
    }

    public void FireGunOn()
    {
        isFireGun = true;
    }

    public void FireGunOff()
    {
        isFireGun = false;
    }
}
