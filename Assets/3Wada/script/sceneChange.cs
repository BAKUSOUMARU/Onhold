using UnityEngine.SceneManagement;
using Onhold.Enums;

namespace Onhold.SceneLoader
{
    public class SceneChange
    {
        public static void NextScene(int scenesIndex)
        {
            var sceceName = (Scenes)scenesIndex;
            SceneManager.LoadScene(sceceName.ToString());
        }
    }
}
