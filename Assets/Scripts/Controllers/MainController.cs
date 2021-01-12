using UnityEngine;

public class MainController : Singleton<MainController>
{
    [SerializeField] private Player player;

    public Player GetPlayer { get => player; }

    private bool canSwipe = true;

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
        canSwipe = true;
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
