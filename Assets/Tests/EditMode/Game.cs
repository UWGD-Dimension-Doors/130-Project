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
            Assert.True(TestUtils.GetSceneEnabled(SceneName));
        }
    }

    [Test]
    public void TestUnexpectedScenesNotEnabled()
    {
        string UnexpectedScene = "SampleScene";

        Assert.False(TestUtils.GetSceneEnabled(UnexpectedScene));
    }
}