using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenView : MonoBehaviour
{
    [SerializeField]
    Text oxugenText;//�_�fText

    public void SetOxygen(float oxygen)
    {
        oxugenText.text = string.Format("{0:000}oxy", oxygen);
    }
}
