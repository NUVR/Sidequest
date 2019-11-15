using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    // guarantee this will be always a singleton only - can't use the constructor!
    protected SceneLoader() { }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("Loading");

        StartCoroutine(LoadAfterTimer(sceneName));
    }

    private IEnumerator LoadAfterTimer(string sceneName)
    {
        // the reason we use a coroutine is simply to avoid a quick "flash" of the 
        // loading screen by introducing an artificial minimum load time :boo:
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene(sceneName);
    }
}


static class SceneNames
{
    public const string INVENTORY = "Inventory";
    public const string NAVIGATION = "Navigation";
}