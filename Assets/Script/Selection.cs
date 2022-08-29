using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    static GameManager gameManager;

    public int selectIdx;
    public GameObject shade;
    public GameObject btnMain;
    public GameObject btnPlay;
    public GameObject btnLock;
    public GameObject btnLearn;

    public Image[] stars;
    public Sprite starImg;

    bool completed;
    bool locked;
    int starsTotal;

    void OnEnable()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        completed = gameManager.levels[selectIdx].lvlCompleted;
        locked = gameManager.levels[selectIdx].lvlLocked;
        starsTotal = gameManager.levels[selectIdx].lvlPoints;

        if (completed)
        {
            for (var i = 0; i < starsTotal; i++)
                stars[i].sprite = starImg;
        }
    }

    public void PlayMode() {
        btnMain.SetActive(true);
        btnLearn.SetActive(false);

        for (var i = 0; i < stars.Length; i++){
            stars[i].gameObject.SetActive(true);
        }
        
        if (!locked)
        {
            btnMain.GetComponent<Button>().interactable = true;
            shade.SetActive(false);
            btnPlay.SetActive(true);
            btnLock.SetActive(false);
        }
        else
        {
            btnMain.GetComponent<Button>().interactable = false;
            shade.SetActive(true);
            btnPlay.SetActive(false);
            btnLock.SetActive(true);
        }
    }

    public void LearnMode() {
        // Debug.Log("ZZ");
        btnMain.SetActive(false);
        btnLearn.SetActive(true);
        shade.SetActive(false);

        for (var i = 0; i < stars.Length; i++){
            stars[i].gameObject.SetActive(false);
        }
    }
}
