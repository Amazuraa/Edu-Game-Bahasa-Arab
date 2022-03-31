using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesManager : MonoBehaviour
{
    static GameManager gameManager;
    public Snap target;
    public Choices[] childs = new Choices[3];
    public List<GameKeywords> choices = new List<GameKeywords>();


    void Awake() {
        target.changeNumber += RefreshChoices;
        target.changeChoices += NewChoices;
    }

    void Start()
    {
        
    }

    void NewChoices() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        int length = gameManager.keywordsKelas.Length;

        choices.Clear();

        int answerIdx = target.number - 1;
        string answerName = target.keyword[answerIdx].keyName;

        int placement = Random.Range(0, 3);
        int storeIdx = -1;

        for (int i = 0; i < 3; i++) 
        {
            if (i == placement) 
                choices.Add(target.keyword[answerIdx]);
            else
            {
                int idx = Random.Range(0, length);

                if (answerName == gameManager.keywordsKelas[idx].keyName || storeIdx == idx)
                    idx = Random.Range(0, length);

                choices.Add(gameManager.keywordsKelas[idx]);
                storeIdx = idx;
            }

            childs[i].objName = choices[i].keyName;
            childs[i].objImage = choices[i].keyImage;

            SpriteRenderer x = childs[i].gameObject.GetComponent<SpriteRenderer>(); 
            x.sprite = choices[i].keyImage;
        }
    }

    void RefreshChoices() {
        NewChoices();
    }
}
