using UnityEngine;

public class MainController : Singleton<MainController>
{
    public delegate void Move();
    public event Move AfterMove;

    [SerializeField] private Player playerPrefab;

    private Player player;

    private bool canSwipe = false;

    private bool isWinLevel = false;
    public bool IsWinLevel { set => isWinLevel = value; }

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

    public void SwipeStart(Direction direction)
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
        LoseLevel();
    }

    public void LoseLevel()
    {
        UiController.Instance.ShowLosePanel();
        player.DestroyCharacter();
    }

    private void WinLevel()
    {
        UiController.Instance.ShowWinPanel();
    }

    public void RestartLevel()
    {
        LevelController.Instance.DestroyLevel();
        CreateLevel();
    }

    public void NextLevel()
    {
        isWinLevel = false;
        player.DestroyCharacter();

        LevelController.Instance.NextLevel();
        CreateLevel();
    }

}
