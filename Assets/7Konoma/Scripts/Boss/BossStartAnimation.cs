using UnityEngine;
using DG.Tweening;
using Cinemachine;
using System.Collections;

/// <summary>
/// ボスエリアに入った場合にカメラをボスに向ける演出
/// </summary>
public class BossStartAnimation : MonoBehaviour
{
    [SerializeField]
    [Header("カメラのオブジェト")]
    GameObject _camera;

    [SerializeField]
    [Header("ボスのオブジェクト")]
    GameObject _Boss;

    float _BossPos;

    [SerializeField]
    [Header("カメラの移動時間")]
    float _moveTimer;

    [SerializeField]
    [Header("ボスを映す時間")]
    int _stayTime;

    [SerializeField]
    CinemachineBrain _brain;

    /// <summary>
    /// ボスエリア内に始めて入った際に呼ばれる
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player2D")
        {
            Debug.Log("ボスの範囲内に入った");
            _brain.enabled = false;

            _BossPos = _Boss.transform.position.x;

            IEnumerator ienumerator = MoveCamera();
            StartCoroutine(ienumerator);
        }
    }

    IEnumerator MoveCamera()
    {     
        var sequence = DOTween.Sequence();
        sequence.Append(_camera.transform.DOMoveX(_BossPos, _moveTimer));

        yield return new WaitForSeconds(_stayTime);
        _brain.enabled = true;
        _ = GetComponent<Collider2D>().enabled = false;
    }
}
