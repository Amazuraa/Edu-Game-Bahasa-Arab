using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    // Variables
    public GameLevels[] levels;
    public GameKeywords[] keywordsKelas;
    public GameKeywords[] keywordsRumah;
    public GameKeywords[] keywordsBuah;

    void Awake()
    {
        if(instance == null){
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		} 
        else 
			Destroy(gameObject);        
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
    public AudioClip keyClip;
}
