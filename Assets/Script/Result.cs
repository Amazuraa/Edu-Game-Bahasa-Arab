using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    static GameManager gameManager;
    private int idxMode;

    public Text titleText;
    public Text scoreText;
    public Sprite starImg;
    public Image[] stars;
    public Buttons parent;
    public GameObject panelReward;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        
        // get level mode index
        int j = 0;
        foreach (GameLevels level in gameManager.levels)
        {
            if (gameManager.keywordsMode == level.lvlName)
                idxMode = j;
            
            j++;
        }

        // set result & stars
        int answer = gameManager.levels[idxMode].lvlAnswered;
        int length = (int) Mathf.Ceil(answer / 3);
        
        titleText.text = (answer >= 6) ? "Selamat!" : "Ooops!" ;

        scoreText.text = answer + "/10";

        if (length != 0)
        {
            for (var i = 0; i < length; i++)
                stars[i].sprite = starImg;
        }

        // next level conditions
        if (answer >= 6)
        {
            gameManager.levels[idxMode].lvlPoints = length;
            gameManager.levels[idxMode].lvlCompleted = true;

            if (idxMode != (gameManager.levels.Length-1))
                gameManager.levels[idxMode+1].lvlLocked = false;
            else {
                panelReward.SetActive(false);

                if (!gameManager.gameFinished) {
                    parent.EventEnd();
                    gameManager.gameFinished = true;
                }
            }

            if (gameManager.levels[idxMode].lvlPoints > gameManager.backupPoints)
                gameManager.SaveGlobal();
        }
        else
        {
            gameManager.levels[idxMode].lvlPoints = gameManager.backupPoints;
            panelReward.SetActive(false);
        }
    }
}
