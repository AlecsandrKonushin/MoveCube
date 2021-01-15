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

    public void ShowBlackoutPanel()
    {
        blackoutPanel.SetActive(true);
    }

    public void ShowWinPanel()
    {
        panelWin.SetActive(true);
    }

    public void ShowLosePanel()
    {
        panelLose.SetActive(true);
    }
}
