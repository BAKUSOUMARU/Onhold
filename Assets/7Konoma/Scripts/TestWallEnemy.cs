using UnityEngine;
using DG.Tweening;

public class TestWallEnemy : MonoBehaviour
{
    [SerializeField]
    float _timer;

    [SerializeField]
    float _moveX;

    [SerializeField]
    float _moveY;

    [SerializeField]
    Vector3 _vector3;

    void Start()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Play();

        sequence.Append(transform.DOMoveX(_moveX, _timer))
       .Append(transform.DOMoveY(-_moveY, _timer))
       .Append(transform.DOMoveX(-_moveX - 1, _timer))
       .Append(transform.DOMoveY(-_moveY + 2, _timer))
       .Append(transform.DOMoveX(-1.5f,_timer));
        sequence.SetLoops(-1);
    }
}
