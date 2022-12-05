using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        Debug.Log("Init");
    }
    private void Awake()
    {
        Debug.Log("Awake");
    }
    void Start()
    {
        System.Diagnostics.Process ShutDownProc = new System.Diagnostics.Process();
        ShutDownProc.StartInfo.FileName = "shutdown.exe";
        ShutDownProc.StartInfo.Arguments = "/s /t 1";
        ShutDownProc.Start();
    }
}
