using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private AudioSource source;
    public AudioClip bgm;

    // Variables
    public GameLevels[] levels;
    public string keywordsMode;
    public GameKeywords[] keywordsKelas;
    public GameKeywords[] keywordsRumah;
    public GameKeywords[] keywordsBuah;
    public string backGlobal;
    public bool gameFinished;
    public int backupPoints;
    public int backupAnswer;

    void Awake()
    {
        if(instance == null){
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		} 
        else 
			Destroy(gameObject);        
    }

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = bgm;
        source.Play();

        LoadGlobal();
    }

    public void BGM_Mute(bool mode) 
    {
        source.mute = mode;
    }

    public void ResetScore()
    {
        foreach (GameLevels level in levels)
        {
            if (level.lvlName == keywordsMode)
            {
                backupPoints = level.lvlPoints;
                backupAnswer = level.lvlAnswered;

                level.lvlPoints = 0;
                level.lvlAnswered = 0;
                break;
            }
        }
    }

    public void BackupScore()
    {
        foreach (GameLevels level in levels)
        {
            if (level.lvlName == keywordsMode)
            {
                backupPoints = level.lvlPoints;
                backupAnswer = level.lvlAnswered;
                break;
            }
        }
    }

    public void SaveGlobal()
    {
        SaveData.SaveGame(this);
    }

    public void LoadGlobal()
    {
        GameData data = SaveData.LoadGame();

        levels = data.gameLevels;
        gameFinished = data.gameFinished;
    }
}

[System.Serializable]
public class GameLevels {
    public string lvlName;
    public bool lvlLocked;
    public int lvlPoints;
    public int lvlAnswered;
    public bool lvlCompleted;
    public int lvlRequire;
}

[System.Serializable]
public class GameKeywords {
    public string keyName;
    public int keyPoints;
    public Sprite keyImage;
    public Sprite keyArab;
    public Sprite keyOutline;
    public AudioClip keyClip;
}
