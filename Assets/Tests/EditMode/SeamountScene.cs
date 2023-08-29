
using NUnit.Framework;
using UnityEngine;
using UnityEditor.SceneManagement;

public class SeamountScene
{
    private readonly string[] ExpectedObjects = { "Player", "Totem", "Boss", "Score" };

    [Test]
    public void TestExpectedObjectsExist()
    {
        EditorSceneManager.OpenScene(TestUtils.GetSceneFilePath("Seamount"));

        foreach (string objectName in ExpectedObjects)
        {
            Assert.IsNotNull(GameObject.Find(objectName), "Expected object " + objectName + " does not exist.");
        }
    }

    [Test]
    public void PlayerTotemCollisionLoadsVictoryScene()
    {
        EditorSceneManager.OpenScene(TestUtils.GetSceneFilePath("Seamount"));

        GameObject totem = GameObject.Find("Totem");
        totem.transform.position = Vector3.zero;

        GameObject player = GameObject.Find("Player");
        player.transform.position = Vector3.zero;

        TestUtils.AssertSceneLoaded("Victory");
    }
}

