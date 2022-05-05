using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneToLoad;
    public string settingsScene;

    public void Play()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }

    public void OpenSettingsMenu()
    {
        SceneManager.LoadScene(settingsScene);
    }
}
