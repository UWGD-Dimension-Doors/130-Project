
using NUnit.Framework;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.UI;

public class TitleScene
{
    [Test]
    public void TestTitleExists()
    {
        EditorSceneManager.OpenScene(TestUtils.GetSceneFilePath("Title"));

        GameObject title = GameObject.Find("Title");
        Assert.IsNotNull(title, "Missing Title text");
    }

    [Test]
    public void TestStartButtonExists()
    {
        EditorSceneManager.OpenScene(TestUtils.GetSceneFilePath("Title"));

        GameObject buttonObject = GameObject.Find("Button");
        Assert.IsNotNull(buttonObject, "Missing Button object");

        Button buttonComponent = buttonObject.GetComponent<Button>();
        Assert.IsNotNull(buttonComponent, "Missing Button component in Button object");
    }

    [Test]
    public void TestStartButtonLoadsSeamount()
    {
        string SceneToLoad = "Seamount";

        EditorSceneManager.OpenScene(TestUtils.GetSceneFilePath("Title"));

        Button button = GameObject.Find("Button").GetComponent<Button>();

        button.onClick.Invoke();

        TestUtils.AssertSceneLoaded(SceneToLoad);
    }
}

