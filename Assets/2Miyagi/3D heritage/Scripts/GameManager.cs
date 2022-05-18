using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private IEnumerator Inoperable(float i){
        GameObject inputObj = GameObject.Find("MainCamera");
        playerCamera inputScript = inputObj.GetComponent<playerCamera>();
        inputScript.enabled = false;
        yield return new WaitForSeconds(i);
        inputScript.enabled = true;
        yield break;
    }
    public void CallInoperrable(float i){
        StartCoroutine("Inoperable", i);
    }
}
