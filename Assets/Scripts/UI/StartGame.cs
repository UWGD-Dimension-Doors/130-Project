using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.UI
{
    /// <summary>
    /// A title screen with a button to load the first level.
    /// </summary>
    public class StartGame : MonoBehaviour
    {
        public string LevelName;

        public void LoadLevel()
        {
            Debug.Log("Loading level: " + LevelName);
            SceneManager.LoadScene(LevelName);
        }
    }
}