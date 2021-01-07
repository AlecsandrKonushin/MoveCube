using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    GameObject panelButtons;

    [SerializeField]
    GameObject panelStart;

    [SerializeField]
    GameObject panelOptions;

    [SerializeField]
    Text textLevel;

    public void LoadLevel()
    {
        //SceneManager.LoadScene(ScoreController.maxLevel);
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
