using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public CameraController cameraCon;
    [SerializeField]
    private int nowLevel;

    public Player player;

    /// <summary>
    /// ui элементы
    /// </summary>
    [SerializeField]
    GameObject StartButton;
    [SerializeField]
    GameObject RulesImage;

    public ScoreController scoreCon;

    private void Start()
    {
        if (cameraCon == null)
            cameraCon = FindObjectOfType<CameraController>();
        if (scoreCon == null)
            scoreCon = FindObjectOfType<ScoreController>();

        scoreCon.NowLevel = nowLevel;
    }
    
    public void StartLevel()
    {
        StartCoroutine(cameraCon.CoCameraStartPos());
        StartButton.SetActive(false);
        RulesImage.SetActive(false);
    }

    public IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(2f);

        if (scoreCon == null)
            scoreCon = FindObjectOfType<ScoreController>();
        
        SceneManager.LoadScene(scoreCon.NowLevel + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(scoreCon.NowLevel);
    }

    public void LoadMenu()
    {
        Destroy(FindObjectOfType<SoundController>().gameObject);
        SceneManager.LoadScene(0);
    }
}
