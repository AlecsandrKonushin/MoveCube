using UnityEngine;

public class LevelPrefab : MonoBehaviour
{
    [SerializeField] private Vector2 startPlayerPos;

    public Vector2 GetStartPlayerPos { get => startPlayerPos; }
}
