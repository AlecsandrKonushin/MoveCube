using UnityEngine;

public class LevelController : Singleton<LevelController>
{
    [SerializeField] private LevelPrefab[] prefabLessonLevels;
    [SerializeField] private LevelPrefab[] prefabLevels;
    [SerializeField] private Vector2 spawnLevelPos;
    [SerializeField] private bool lessonLevels;

    private int currentLevelNumber = 0;

    private LevelPrefab[] changeLevels;
    private LevelPrefab currentLevel;
    public LevelPrefab CurrrentLevel { get => currentLevel; }

    public override void Awake()
    {
        base.Awake();

        if (lessonLevels)
            changeLevels = prefabLessonLevels;
        else
            changeLevels = prefabLevels;
    }

    public void CreateCurrentLevel()
    {
        if (currentLevelNumber >= changeLevels.Length)
        {
            changeLevels = prefabLevels;
            currentLevelNumber = 0;
        }

        currentLevel = Instantiate(changeLevels[currentLevelNumber], spawnLevelPos, Quaternion.identity);
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
