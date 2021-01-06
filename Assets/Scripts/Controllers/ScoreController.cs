using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController scoreCon;

    private void Start()
    {
        if (scoreCon == null)
            scoreCon = GetComponent<ScoreController>();
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] private int nowLevel = 1;
    public int NowLevel
    {
        get { return nowLevel; }
        set
        {
            nowLevel = value;
            if (value > maxLevel)
            {
                maxLevel = value;
                LoadSave.Save(maxLevel);
            }
        }
    }

    public static int maxLevel = 1;

    private void Awake()
    {
        maxLevel = 1;
        
        maxLevel = LoadSave.Load();
        if (maxLevel == 0)
            maxLevel = 1;
    }
}
