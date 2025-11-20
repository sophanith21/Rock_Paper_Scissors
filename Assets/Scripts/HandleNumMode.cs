using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleNumMode : MonoBehaviour
{
    public GameObject normalPanel;
    public GameObject advancePanel;

    public bool isNormal = false;

    public bool isAdvance = false;

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

}
