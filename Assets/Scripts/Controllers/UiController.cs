using System.Collections;
using UnityEngine;

public class UiController : Singleton<UiController>
{
    [SerializeField] private GameObject blackoutPanel;

    [SerializeField] private GameObject panelWin;
    [SerializeField] private GameObject panelLose;

    public void HideBlackoutPanel()
    {
        StartCoroutine(CoHideBlackoutPanel());
    }

    private IEnumerator CoHideBlackoutPanel()
    {
        blackoutPanel.GetComponent<Animator>().SetTrigger("hide");
        yield return new WaitForSeconds(.5f);
        blackoutPanel.SetActive(false);
    }

    public void ShowWinPanel()
    {
        panelWin.SetActive(true);
    }

    public void ShowLosePanel()
    {
        panelLose.SetActive(true);
    }

    public void ClickRestartLevel()
    {
        StartCoroutine(CoClickRestartLevel());
    }

    private IEnumerator CoClickRestartLevel()
    {
        panelLose.SetActive(false);
        blackoutPanel.SetActive(true);

        yield return new WaitForSeconds(.5f);

        MainController.Instance.RestartLevel();
    }
}
