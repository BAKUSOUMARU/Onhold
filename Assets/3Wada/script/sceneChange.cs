using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneChange : MonoBehaviour
{
    [SerializeField] string retrysceneName;
    [SerializeField] string nextsceneName;

    void Start()
    {
        GameManager.instance.retrysceneName = retrysceneName;
        GameManager.instance.NextsceneName = nextsceneName;
    }

}
