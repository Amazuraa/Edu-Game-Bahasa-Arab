using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesManager : MonoBehaviour
{
    static GameManager gameManager;
    public Snap target;
    public Sprite arabOutline;
    public Choices[] childs = new Choices[3];
    public List<GameKeywords> choices = new List<GameKeywords>();

    private GameKeywords[] keywords;

    void Awake() {
        target.changeNumber += RefreshChoices;
        target.changeChoices += NewChoices;
    }

    void Start()
    {
        
    }

    void NewChoices() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        switch (gameManager.keywordsMode)
        {
            case "Buah":
                keywords = gameManager.keywordsBuah;
                break;
            case "Kelas":
                keywords = gameManager.keywordsKelas;
                break;
            case "Rumah":
                keywords = gameManager.keywordsRumah;
                break;
        }

        int length = keywords.Length;

        choices.Clear();

        int answerIdx = target.number - 1;
        bool odd = (target.number % 2 == 0) ? true : false;

        string answerName = target.keyword[answerIdx].keyName;

        int placement = Random.Range(0, childs.Length);
        int storeIdx = -1;

        for (int i = 0; i < childs.Length; i++) 
        {
            if (i == placement) 
                choices.Add(target.keyword[answerIdx]);
            else
            {
                int idx = Random.Range(0, length);

                if (answerName == keywords[idx].keyName || storeIdx == idx)
                    idx = Random.Range(0, length);

                choices.Add(keywords[idx]);
                storeIdx = idx;
            }

            childs[i].objName = choices[i].keyName;

            if (!odd) {
                
                childs[i].objImage = choices[i].keyImage;
                childs[i].objImageOutline = choices[i].keyOutline;
            }
            else {
                // childs[i].StateAnim(true);
                childs[i].objImage = choices[i].keyArab;
                childs[i].objImageOutline = arabOutline;
            }

            if (!odd)
                childs[i].StateAnim(false);
            else
                childs[i].StateAnim(true);

            childs[i].ChangeImage();

            
            // SpriteRenderer x = childs[i].gameObject.GetComponent<SpriteRenderer>(); 
            // x.sprite = choices[i].keyImage;

            
        }
    }

    void RefreshChoices() {
        NewChoices();
    }

    // IEnumerator DelayChoice() {
	// 	yield return new WaitForSeconds(.2f);

    // }
}
