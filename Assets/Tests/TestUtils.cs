using NUnit.Framework;
using System.Collections;
using UnityEditor;

public class TestUtils
{
    public static bool GetSceneEnabled(string sceneName)
    {
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.path.Contains(sceneName))
            {
                return scene.enabled;
            }
        }

        return false;
    }

    public static string GetSceneFilePath(string sceneName)
    {
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.path.Contains(sceneName))
            {
                return scene.path;
            }
        }

        return "";
    }

    public static IEnumerator AssertSceneLoaded(string sceneName)
    {
        WaitForSceneLoaded waitForScene = new(sceneName);

        yield return waitForScene;

        Assert.IsFalse(waitForScene.TimedOut, "Scene " + sceneName + " was never loaded");
    }
}