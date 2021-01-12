using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private bool exitDoor = false;
    public bool ExitDoor { get => exitDoor; }
}
