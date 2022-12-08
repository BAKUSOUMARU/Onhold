using UnityEngine.SceneManagement;
using Onhold.Enums;

namespace Onhold.Scene
{
    public class SceneChange
    {
        public static void ChangeScene(int scenesIndex)
        {
            var sceceName = (Scenes)scenesIndex;
            SceneManager.LoadScene(sceceName.ToString());
        }

        public static void GameOverScene()
        {
            SceneManager.LoadScene("GameOver");
        }

    }
}
