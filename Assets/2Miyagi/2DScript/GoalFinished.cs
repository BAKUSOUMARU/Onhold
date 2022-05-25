using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalFinished : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player"){
            Debug.Log("finish");
        }
    }
}
