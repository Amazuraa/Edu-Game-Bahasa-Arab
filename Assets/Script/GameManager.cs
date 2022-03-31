using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables
    public GameLevels[] levels;
    public GameKeywords[] keywordsKelas;
    public GameKeywords[] keywordsRumah;
    public GameKeywords[] keywordsBuah;

    // Start is called before the first frame update
    void Start()
    {
        
    }
}

[System.Serializable]
public class GameLevels {
    public string lvlName;
    public bool lvlLocked;
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
