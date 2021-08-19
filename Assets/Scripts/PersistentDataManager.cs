using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentDataManager : MonoBehaviour
{
    [SerializeField] string[] playerPrefsNames;
    [SerializeField] int[] levelScores;
    static public PersistentDataManager instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        levelScores = new int[playerPrefsNames.Length];
        for (int i = 0; i < playerPrefsNames.Length; i++)
        {
            if (PlayerPrefs.HasKey(playerPrefsNames[i]))
                levelScores[i] = PlayerPrefs.GetInt(playerPrefsNames[i]);
        }
    }

    public int GetLevelScore(int level)
    {
        return levelScores[level - 1];
    }

    public void SetLevelScore(int level, int score)
    {
        levelScores[level - 1] = score;
    }

    public void SaveData()
    {
        for (int i = 0; i < playerPrefsNames.Length; i++)
        {
            PlayerPrefs.SetInt(playerPrefsNames[i], levelScores[i]);
        }
    }
    public int GetNextNotClearedLevel()
    {
        for (int i = 0; i < levelScores.Length; i++)
        {
            if (levelScores[i] == 0)
                return i + 1;
        }
        return 1;
    }
}
