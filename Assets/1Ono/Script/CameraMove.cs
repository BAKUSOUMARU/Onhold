using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.DOMove(new Vector3(40.27f, -0.82f, -10f), 20f).SetLoops(-1, LoopType.Restart);
    }
}
