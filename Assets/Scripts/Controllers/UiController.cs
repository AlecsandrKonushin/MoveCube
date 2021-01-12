using UnityEngine;

public class UiController : Singleton<UiController>
{
    [SerializeField] private GameObject panelWin;

    public void ShowWinPanel()
    {
        panelWin.SetActive(true);
    }
}
