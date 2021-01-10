using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int nowLevel;

    public void NextLevel()
    {
        //if (scoreCon == null)
        //    scoreCon = FindObjectOfType<ScoreController>();

        //SceneManager.LoadScene(scoreCon.NowLevel + 1);
    }

    public void RestartLevel()
    {
        //SceneManager.LoadScene(scoreCon.NowLevel);
    }

    public void LoadMenu()
    {
        //Destroy(FindObjectOfType<SoundController>().gameObject);
        //SceneManager.LoadScene(0);
    }
}
