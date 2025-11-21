using UnityEngine;

public class RestartButton : MonoBehaviour
{

    public void OnClick()
    {
        SceneSwitcher.Instance.GoBack();
    }
}
