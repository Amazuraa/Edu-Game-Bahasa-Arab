using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LearningHeader : MonoBehaviour
{
    public Text headerTxt;
    static GameManager gameManager;


    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        headerTxt.text = gameManager.keywordsMode;
    }
}
