using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanelController : Singleton<SettingsPanelController>
{
    [SerializeField] private GameObject settingsPanel;

    public bool SettingsPanelIsActive()
    {
        return settingsPanel.activeSelf;
    }

    public void ShowPanel()
    {
        SwipeController.Instance.CanSwipe = false;
        settingsPanel.SetActive(true);
    }

    public void ChangeMusicVolume(Slider slider)
    {
        AudioController.Instance.SetMusicVolume = slider.value;
    }

    public void ChangeSoundVolume(Slider slider)
    {
        AudioController.Instance.SetSoundVolume = slider.value;
    }

    public void HidePanelSettings()
    {
        StartCoroutine(CoHidePanelSettings());
    }

    private IEnumerator CoHidePanelSettings()
    {
        settingsPanel.GetComponent<Animator>().SetTrigger("hide");
        yield return new WaitForSeconds(.5f);
        settingsPanel.SetActive(false);
        SwipeController.Instance.CanSwipe = true;
    }

    public void ClickExitButton()
    {
        MainController.Instance.ExitApp();
    }
}
