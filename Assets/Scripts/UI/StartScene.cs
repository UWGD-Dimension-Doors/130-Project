using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.UI
{
    /// <summary>
    /// A utility class to load a scene.
    /// </summary>
    public class StartScene : MonoBehaviour
    {
        public string LevelName;

        public void LoadLevel()
        {
            SceneManager.LoadScene(LevelName);
        }
    }
}