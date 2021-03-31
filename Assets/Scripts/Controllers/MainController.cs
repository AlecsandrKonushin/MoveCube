using UnityEngine;

public class MainController : Singleton<MainController>
{
    public delegate void Move();
    public event Move AfterMove;

    [SerializeField] private Player playerPrefab;

    private Player player;

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
        SwipeController.Instance.CanSwipe = true;
    }

    public void SwipeStart(Direction direction)
    {
        SwipeController.Instance.CanSwipe = false;
        player.SetNewPosition(direction);
    }

    public void PlayerEndMove()
    {
        if (isWinLevel)
            WinLevel();
        else if(!SettingsPanelController.Instance.SettingsPanelIsActive()) // Если не открыта панель Settings, то можно делать свайпы
            SwipeController.Instance.CanSwipe = true;
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
        if (player != null)
            Destroy(player.gameObject);
        CreateLevel();
    }

    public void NextLevel()
    {
        isWinLevel = false;
        player.DestroyCharacter();

        LevelController.Instance.NextLevel();
        CreateLevel();
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
