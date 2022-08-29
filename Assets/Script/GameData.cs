using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public GameLevels[] gameLevels;
    public bool gameFinished;

    public GameData (GameManager gameManager)
    {
        gameLevels = gameManager.levels;
        gameFinished = gameManager.gameFinished;
    }
}
