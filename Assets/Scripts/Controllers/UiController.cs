using UnityEngine;

public class UiController : Singleton<UiController>
{
    [SerializeField] private GameObject panelWin;
    [SerializeField] private GameObject panelLose;

    public void ShowWinPanel()
    {
        panelWin.SetActive(true);
    }

    public void ShowLosePanel()
    {
        panelLose.SetActive(true);
    }
}
