using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stage1enemyscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Sequence�̃C���X�^���X���쐬
        var sequence = DOTween.Sequence();

        //Append�œ����ǉ����Ă���
        sequence.Append(this.transform.DOMoveX(5f, 2f).SetLoops(-1,LoopType.Yoyo));
        sequence.Append(this.transform.DOMoveY(5f, 1f).SetLoops(-1, LoopType.Yoyo));
        //Play�Ŏ��s
        sequence.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
