using System.Collections;
using UnityEngine;

public class UiController : Singleton<UiController>
{
    [SerializeField] private GameObject blackoutPanel;

    [SerializeField] private GameObject panelWin;
    [SerializeField] private GameObject panelLose;

    [SerializeField] private GameObject panelButtonsUp;

    private float timeAnim = .5f;

    public void HideBlackoutPanel()
    {
        StartCoroutine(CoHidePanel(blackoutPanel));
        panelButtonsUp.SetActive(true);
    }

    #region Win level
    public void ShowWinPanel()
    {
        panelWin.SetActive(true);
        StartCoroutine(CoHidePanel(panelButtonsUp));
    }

    public void ClickWinLevel()
    {
        StartCoroutine(CoClickWinLevel());
    }

    private IEnumerator CoClickWinLevel()
    {
        StartCoroutine(CoHidePanel(panelWin));

        yield return new WaitForSeconds(timeAnim);
        blackoutPanel.SetActive(true);
        yield return new WaitForSeconds(timeAnim);

        MainController.Instance.NextLevel();
    }
    #endregion

    #region Lose level
    public void ShowLosePanel()
    {
        panelLose.SetActive(true);
        StartCoroutine(CoHidePanel(panelButtonsUp));
    }

    public void ClickRestartLevel()
    {
        StartCoroutine(CoClickRestartLevel());
    }

    private IEnumerator CoClickRestartLevel()
    {
        StartCoroutine(CoHidePanel(panelLose));

        yield return new WaitForSeconds(timeAnim);
        blackoutPanel.SetActive(true);

        MainController.Instance.RestartLevel();
    }
    #endregion

    #region
    public void ShowSettingsPanel()
    {
        SettingsPanelController.Instance.ShowPanel();
    }
    #endregion

    private IEnumerator CoHidePanel(GameObject panel)
    {
        panel.GetComponent<Animator>().SetTrigger("hide");
        yield return new WaitForSeconds(timeAnim);
        panel.SetActive(false);
    }
}
