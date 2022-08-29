using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLearning : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public string btnMode;
    public ButtonLearning btnSibling;
    public Learning objLearning;
    static GameManager gameManager;
    public GameKeywords[] keywords;
    public int length;
    public int idx = 0;


    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        switch (gameManager.keywordsMode)
        {
            case "Buah":
                // keywords = gameManager.keywordsBuah;
                length = (gameManager.keywordsBuah.Length - 1);
                break;
            case "Kelas":
                // keywords = gameManager.keywordsKelas;
                length = (gameManager.keywordsKelas.Length - 1);
                break;
            case "Rumah":
                // keywords = gameManager.keywordsRumah;
                length = (gameManager.keywordsRumah.Length - 1);
                break;
        }
    }

    public void LearningPress() {
        source.clip = clip;
        source.Play();

        switch (btnMode)
        {
            case "Next":
                idx++;
                break;
            case "Prev":
                idx--;
                break;
        }
        
        // checking..
        if (idx > length) idx = length;
        else if (idx <= 0) idx = 0;

        // update sibling index..
        btnSibling.idx = idx;

        // update object images..
        objLearning.ChangeIdx(idx);
    }
}
