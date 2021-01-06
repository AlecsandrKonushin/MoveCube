using System.Collections;
using System.Collections.Generic;
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
        Debug.Log(ScoreController.maxLevel);
        SceneManager.LoadScene(ScoreController.maxLevel);
    }

    private void Start()
    {
        textLevel.text = "уровень : " + ScoreController.maxLevel;
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
