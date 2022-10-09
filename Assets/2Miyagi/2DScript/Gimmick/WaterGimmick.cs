using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gimmick.Water
{
    public class WaterGimmick : MonoBehaviour
    {
        [SerializeField] GameObject _waterTrap;
        [SerializeField] float _riseAddScale = 0.01f;
        
        float _riseScaleSize = 1;
        Transform _tr;
        Vector3 defaultWaterVector;

        
        float _streamScaleSize;
        [SerializeField]
        float _streamAddScale = 0.1f;

        public float _finishChangeWater = 5f;

        [Space()]
        public bool _waterSwitch = false;
        public bool _runningWater= false;

        private void Start()
        {
            this.tag = "Water";
            _tr = GetComponent<Transform>();
            print(transform.localScale);
            defaultWaterVector = transform.localScale;
            _riseScaleSize = defaultWaterVector.y;
            _streamScaleSize = defaultWaterVector.x;
        }
        private void FixedUpdate()
        {
            if (_waterSwitch)
            {
                WaterLevelIncrease();
                Coroutine coroutine = StartCoroutine("FinishWaterChange", _finishChangeWater);
            }
            if (_runningWater)
            {
                WaterStream();
                Coroutine coroutine = StartCoroutine("FinishWaterChange", _finishChangeWater);
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            /*if(col.gameObject.tag == "Substance")
            {
                Destroy(col.gameObject); //これはtag追加したときにコメントアウト外してください
            }//水に触れたとき「 Substance 」オブジェクトを破壊する*/
        }

        /// <summary>
        /// 縦に水が増える
        /// </summary>
        public void WaterLevelIncrease()
        {
            this.transform.localScale = new Vector3(defaultWaterVector.x, _riseScaleSize, defaultWaterVector.z);
            _riseScaleSize += _riseAddScale;
        }

        /// <summary>
        /// 横に水が増える
        /// </summary>
        public void WaterStream()
        {
            this.transform.localScale = new Vector3(_streamScaleSize, defaultWaterVector.y, defaultWaterVector.z);
            _streamScaleSize += _streamAddScale;
        }

        private IEnumerator FinishWaterChange(float finishChange)
        {
            yield return new WaitForSeconds(_finishChangeWater);
            _waterSwitch = false;
            _runningWater = false;
        }//水が変化し終わるまでの遅延
    }
}

