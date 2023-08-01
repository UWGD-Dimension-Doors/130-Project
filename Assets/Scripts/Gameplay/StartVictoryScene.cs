using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartVictoryScene : MonoBehaviour
{
    private readonly string VictorySceneName = "Victory";
    private int SecondsToDelay = 3;

    public void StartAfterDelay()
    {
        StartCoroutine(LoadVictorySceneAfterDelay(SecondsToDelay));
    }

    private IEnumerator LoadVictorySceneAfterDelay(int seconds)
    {
        // Wait a few seconds before loading the victory scene
        // so victory animations can complete.
        yield return new WaitForSeconds(seconds);

        SceneManager.LoadScene(VictorySceneName);
    }
}

