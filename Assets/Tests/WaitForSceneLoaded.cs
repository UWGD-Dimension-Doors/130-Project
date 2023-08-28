using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitForSceneLoaded : CustomYieldInstruction
{
    private readonly string sceneName;
    private readonly float timeout;
    private readonly float startTime;
    private bool timedOut;

    public bool TimedOut => timedOut;

    public override bool keepWaiting
    {
        get
        {
            Scene scene = SceneManager.GetSceneByName(sceneName);
            bool sceneLoaded = scene.IsValid() && scene.isLoaded;

            if (Time.realtimeSinceStartup - startTime >= timeout)
            {
                timedOut = true;
            }

            return !sceneLoaded && !timedOut;
        }
    }

    public WaitForSceneLoaded(string newSceneName, float newTimeout = 10)
    {
        sceneName = newSceneName;
        timeout = newTimeout;
        startTime = Time.realtimeSinceStartup;
    }
}