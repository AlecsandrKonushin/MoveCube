using UnityEngine;

public class SwipeController : Singleton<SwipeController>
{
    public delegate void DoSwipe();
    public event DoSwipe AfterSwipe;

    private bool canSwipe = false;
    public bool CanSwipe { set => canSwipe = value; }

    private Vector3 firstPress;
    private Vector3 lastPress;
    private float minDragDistance = 1;

    private void Update()
    {
        if (!canSwipe)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            firstPress = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            lastPress = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Mathf.Abs(lastPress.x - firstPress.x) > minDragDistance || Mathf.Abs(lastPress.y - firstPress.y) > minDragDistance)
            {
                if (Mathf.Abs(lastPress.x - firstPress.x) > Mathf.Abs(lastPress.y - firstPress.y))
                {
                    if ((lastPress.x > firstPress.x))
                    {
                        MainController.Instance.SwipeStart(Direction.Right);
                    }
                    else
                    {
                        MainController.Instance.SwipeStart(Direction.Left);
                    }
                }
                else
                {
                    if (lastPress.y > firstPress.y)
                    {
                        MainController.Instance.SwipeStart(Direction.Up);
                    }
                    else
                    {
                        MainController.Instance.SwipeStart(Direction.Down);
                    }
                }
            }

            AfterSwipe?.Invoke();
        }
    }
}

public enum Direction
{
    Up,
    Right,
    Down,
    Left
}
