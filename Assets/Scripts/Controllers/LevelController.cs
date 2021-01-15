using UnityEngine;

public class LevelController : Singleton<LevelController>
{
    [SerializeField] private LevelPrefab[] prefablevels;
    [SerializeField] private Vector2 spawnLevelPos;

    private int currentLevelNumber = 0;

    private LevelPrefab currentLevel;
    public LevelPrefab CurrrentLevel { get => currentLevel; }

    public void CreateCurrentLevel()
    {
        currentLevel = Instantiate(prefablevels[currentLevelNumber], spawnLevelPos, Quaternion.identity);
    }

    public void DestroyLevel()
    {
        Destroy(currentLevel.gameObject);
    }

    public void NextLevel()
    {
        DestroyLevel();
        currentLevelNumber++;
    }
}
