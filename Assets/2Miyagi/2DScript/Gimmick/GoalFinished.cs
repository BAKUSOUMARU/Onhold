using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalFinished : MonoBehaviour
{
    [SerializeField] int _nowStageNumber = default;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player"){
            Debug.Log("finish");
            JsonStageSelect.Instance.Save(_nowStageNumber);
            SceneManager.LoadScene("GameClear");
        }
    }
}
