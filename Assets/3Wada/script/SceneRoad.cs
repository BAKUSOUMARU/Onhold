using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRoad : MonoBehaviour
{
   public void  Sceneroad(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
