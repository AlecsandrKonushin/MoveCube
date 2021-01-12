using UnityEngine;

public class MainController : Singleton<MainController>
{
    public delegate void Move();
    public event Move AfterMove;

    [SerializeField] private Player player;
    public Player GetPlayer { get => player; }

    private bool canSwipe = true;
    private bool isWinLevel = false;
    public bool IsWinLevel { set => isWinLevel = value; }

    public void SwipeStart(SwipeDirection direction)
    {
        if (canSwipe)
        {
            canSwipe = false;
            player.SetNewPosition(direction);
        }
    }

    public void PlayerEndMove()
    {
        if (isWinLevel)
            WinLevel();
        else
            canSwipe = true;
    }

    public void PlayerDeath()
    {
        Debug.LogError("Restart level");
    }

    private void WinLevel()
    {
        UiController.Instance.ShowWinPanel();
    }

    public void StartLevel()
    {
        //StartCoroutine(cameraCon.CoCameraStartPos());
        //StartButton.SetActive(false);
        //RulesImage.SetActive(false);
    }

}
