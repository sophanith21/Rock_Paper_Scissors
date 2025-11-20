using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Lose_Menu : MonoBehaviour
{
    public static string previousScene = "";

    public void toMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadScene(string sceneName)
    {
        previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public void GoBack()
    {
        if (previousScene != "")
        {
            SceneManager.LoadScene(previousScene);
        }
        else
        {
            Debug.Log("No previous scene stored!");
        }
    }
}

