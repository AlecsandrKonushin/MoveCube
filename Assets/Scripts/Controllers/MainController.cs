using UnityEngine;

public class MainController : Singleton<MainController>
{
    public delegate void Move();
    public event Move AfterMove;

    [SerializeField] private Player playerPrefab;

    private Player player;

    private bool canSwipe = false;
    private bool isWinLevel = false;
    private bool isLoseLevel = false;

    public bool IsWinLevel { set => isWinLevel = value; }
    public bool IsLoseLevel { set => isLoseLevel = value; }

    private void Start()
    {
        CreateLevel();
    }

    private void CreateLevel()
    {
        LevelController.Instance.CreateCurrentLevel();

        player = Instantiate(playerPrefab, LevelController.Instance.CurrrentLevel.GetStartPlayerPos, Quaternion.identity);

        UiController.Instance.HideBlackoutPanel();
        canSwipe = true;
    }

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
        else if (isLoseLevel)
            LoseLevel();
        else
            canSwipe = true;
    }

    public void LoseLevel()
    {
        player.DestroyPlayer();
        UiController.Instance.ShowLosePanel();
    }

    private void WinLevel()
    {
        UiController.Instance.ShowWinPanel();
    }

    public void RestartLevel()
    {
        isLoseLevel = false;

        LevelController.Instance.DestroyLevel();
        CreateLevel();
    }

    public void NextLevel()
    {
        isWinLevel = false;
        player.DestroyPlayer();

        LevelController.Instance.NextLevel();
        CreateLevel();
    }

}
