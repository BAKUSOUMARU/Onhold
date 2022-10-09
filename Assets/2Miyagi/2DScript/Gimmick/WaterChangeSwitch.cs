using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gimmick.Water;

public class WaterChangeSwitch : MonoBehaviour
{
    [SerializeField]enum ChangeGimmick{
        LevelIncrease,
        Stream
    }//横か縦に増えるか選択する
    
    [Header("ギミックの対象を選択")]
    [SerializeField]WaterGimmick changeTarget;

    [Header("使いたいギミックを選択")]
    [SerializeField]ChangeGimmick changeGimmick;

    [Header("ギミックの継続時間を設定")]
    [SerializeField] float duration;
    private void Start()
    {
        changeTarget._finishChangeWater = duration;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            switch (changeGimmick)
            {
                case ChangeGimmick.LevelIncrease:
                    print("Level");
                    changeTarget._waterSwitch = true;
                    break;
                case ChangeGimmick.Stream:
                    print("Stream");
                    changeTarget._runningWater = true;
                    break;
            }
        }
    }
}
