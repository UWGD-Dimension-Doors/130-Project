
using NUnit.Framework;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.UI;

public class VictoryScene
{
    [Test]
    public void TestVictoryExists()
    {
        EditorSceneManager.OpenScene(TestUtils.GetSceneFilePath("Victory"));

        GameObject title = GameObject.Find("Victory");
        Assert.IsNotNull(title, "Missing Victory text");
    }

    [Test]
    public void TestScoreExists()
    {
        EditorSceneManager.OpenScene(TestUtils.GetSceneFilePath("Victory"));

        GameObject score = GameObject.Find("Your Score");
        Assert.IsNotNull(score, "Missing Your Score text");
    }

    [Test]
    public void TestBackButtonExists()
    {
        EditorSceneManager.OpenScene(TestUtils.GetSceneFilePath("Victory"));

        GameObject buttonObject = GameObject.Find("Button");
        Assert.IsNotNull(buttonObject, "Missing Button object");

        Button buttonComponent = buttonObject.GetComponent<Button>();
        Assert.IsNotNull(buttonComponent, "Missing Button component in Button object");
    }

    [Test]
    public void TestBackButtonLoadsTitle()
    {
        string SceneToLoad = "Title";

        EditorSceneManager.OpenScene(TestUtils.GetSceneFilePath("Victory"));

        Button button = GameObject.Find("Button").GetComponent<Button>();

        button.onClick.Invoke();

        TestUtils.AssertSceneLoaded(SceneToLoad);
    }
}

