using UnityEngine;

public class ToMenuButton : MonoBehaviour
{

    public void OnClick()
    {
        SceneSwitcher.Instance.toMain();
    }
}
