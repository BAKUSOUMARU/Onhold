using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGunBreak : MonoBehaviour
{
    [SerializeField]
    string _iceBreakObjectTag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == _iceBreakObjectTag)
        {
            Destroy(other.gameObject);
        }
    }
}
