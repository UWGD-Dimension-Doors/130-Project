using NUnit.Framework;
using UnityEditor;

public class GameTests
{
    private readonly string[] EnabledScenes = {"Title", "Seamount", "Victory"};

    [Test]
    public void TestExpectedScenesEnabled()
    {
        foreach (string SceneName in EnabledScenes)
        {
            Assert.True(GetSceneEnabled(SceneName));
        }
    }

    [Test]
    public void TestUnexpectedScenesNotEnabled()
    {
        string UnexpectedScene = "SampleScene";

        Assert.False(GetSceneEnabled(UnexpectedScene));
    }

    // Helper function
    private bool GetSceneEnabled(string sceneName)
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
}