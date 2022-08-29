using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Learning : MonoBehaviour
{
    public SpriteRenderer imgMain;
    public SpriteRenderer imgArab;
    public Text transalate;
    public AudioSource source;

    static GameManager gameManager;
    public GameKeywords[] keywords;

    
    void Start() {
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

        // set first images..
        imgMain.sprite = keywords[0].keyImage;
        imgArab.sprite = keywords[0].keyArab;
        transalate.text = keywords[0].keyName;
        source.clip = keywords[0].keyClip;
    }

    public void ChangeIdx(int i) {
        // set image by index..
        imgMain.sprite = keywords[i].keyImage;
        imgArab.sprite = keywords[i].keyArab;
        transalate.text = keywords[i].keyName;
        source.clip = keywords[i].keyClip;
    }

    public void PlayClip() {
        source.Play();
    }
}
