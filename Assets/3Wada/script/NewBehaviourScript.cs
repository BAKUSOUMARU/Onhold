using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public void Shutdown()
    {
        System.Diagnostics.Process ShutDownProc = new System.Diagnostics.Process();
        ShutDownProc.StartInfo.FileName = "shutdown.exe";
        ShutDownProc.StartInfo.Arguments = "/s /t 1";
        ShutDownProc.Start();
    }
}
