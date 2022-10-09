using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gimmick.Water;

public class WaterChangeSwitch : MonoBehaviour
{
    [SerializeField]enum ChangeGimmick{
        LevelIncrease,
        Stream
    }//�����c�ɑ����邩�I������
    
    [Header("�M�~�b�N�̑Ώۂ�I��")]
    [SerializeField]WaterGimmick changeTarget;

    [Header("�g�������M�~�b�N��I��")]
    [SerializeField]ChangeGimmick changeGimmick;

    [Header("�M�~�b�N�̌p�����Ԃ�ݒ�")]
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
