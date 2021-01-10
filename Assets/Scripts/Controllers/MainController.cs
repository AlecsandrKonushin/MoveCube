using UnityEngine;

public class MainController : Singleton<MainController>
{
    [SerializeField] private SwipeController swipeCon;
    [SerializeField] private Player player;

    public Player GetPlayer { get => player; }

    private bool canSwipe = true;

    public void SwipeStart(SwipeDirection direction)
    {
        if (canSwipe)
        {
            canSwipe = false;
            player.SetDirection(direction);
        }
    }

    public void PlayerDeath()
    {
        Debug.LogError("Restart level");
    }

    public void PlayerWinLevel()
    {
        Debug.LogError("Win level");
    }

    public void StartLevel()
    {
        //StartCoroutine(cameraCon.CoCameraStartPos());
        //StartButton.SetActive(false);
        //RulesImage.SetActive(false);
    }

}
