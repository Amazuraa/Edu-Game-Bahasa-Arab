using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    // Defining Delegate
    public delegate void OnAnswerLoaded();
    public OnAnswerLoaded changeChoices;

    public delegate void OnAnswerTrue();
    public OnAnswerTrue changeNumber;

    // Variables
    public SpriteRenderer image;
    public float snapRange = .5f;

    public int number = 1;
    public int maxNumber = 6;
    public List<GameKeywords> keyword = new List<GameKeywords>();

    static GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // get Game Manager
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        int lvlLength = gameManager.keywordsKelas.Length;
        
        // loop for random answer
        for (int i = 0; i < 6; i++) {
            int idx = Random.Range(0, lvlLength);
            keyword.Add(gameManager.keywordsKelas[idx]);
        }

        // send delegate to choices
        changeChoices();

        // set first question image
        image.sprite = keyword[0].keyArab;
    }
    
    public void checkAnswer(GameObject obj) {
        Choices y = obj.GetComponent<Choices>();
        // Debug.Log(y.objName);

        // answer true
        if (y.objName == keyword[number-1].keyName) {
            // change question image
            image.sprite = keyword[number-1].keyArab;

            // next question
            if (number != maxNumber) {
                number++;
                changeNumber();
            }
        }
        else
            Debug.Log(false);
    }

    // public void changeNumber() {
    //     buttonClickDelegate ();
    // }
}
