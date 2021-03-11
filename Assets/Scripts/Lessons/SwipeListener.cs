using UnityEngine;

public class SwipeListener : MonoBehaviour
{
    private void Start()
    {
        SwipeController.Instance.AfterSwipe += DisableObject;
    }

    private void DisableObject()
    {
        SwipeController.Instance.AfterSwipe -= DisableObject;
        gameObject.SetActive(false);
    }
}
