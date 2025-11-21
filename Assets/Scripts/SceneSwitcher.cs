using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher Instance;   // Global access
    public string previousScene = "";       // Stores previous scene

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void toMain()
    {
        LoadScene("MainMenu");
    }

    public void LoadScene(string sceneName)
    {
        // Save previous scene
        previousScene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(sceneName);
    }

    public void GoBack()
    {
        if (!string.IsNullOrEmpty(previousScene))
        {
            SceneManager.LoadScene(previousScene);
        }
        else
        {
            Debug.Log("No previous scene stored!");
        }
    }
}
