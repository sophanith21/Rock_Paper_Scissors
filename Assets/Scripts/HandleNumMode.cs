using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleNumMode : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject normalPanel;
    public GameObject advancePanel;

    [HideInInspector]
    public static bool isNormal = false;
    public static bool isAdvance = false;

    private void Start()
    {
        normalPanel.SetActive(isNormal);
        advancePanel.SetActive(isAdvance);
    }

    public void normalMode()
    {
        isNormal = !isNormal;
        //true: show panel
        normalPanel.SetActive(isNormal);
    }

    public void advanceMode()
    {
        isAdvance = !isAdvance;
        advancePanel.SetActive(isAdvance);
    }

    public void credit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
    }

}
