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

    #region Win level
    public void ShowWinPanel()
    {
        panelWin.SetActive(true);
    }

    public void ClickWinLevel()
    {
        StartCoroutine(CoClickWinLevel());
    }

    private IEnumerator CoClickWinLevel()
    {
        panelWin.GetComponent<Animator>().SetTrigger("hide");
        yield return new WaitForSeconds(.5f);

        panelWin.SetActive(false);
        blackoutPanel.SetActive(true);

        yield return new WaitForSeconds(.5f);

        MainController.Instance.NextLevel();
    }
    #endregion

    #region Lose level
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
        panelLose.GetComponent<Animator>().SetTrigger("hide");
        yield return new WaitForSeconds(.5f);

        panelLose.SetActive(false);
        blackoutPanel.SetActive(true);

        yield return new WaitForSeconds(.5f);

        MainController.Instance.RestartLevel();
    }
    #endregion
}
