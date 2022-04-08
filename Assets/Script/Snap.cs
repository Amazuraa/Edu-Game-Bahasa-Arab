using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject dropPos;
    public List<GameKeywords> keyword = new List<GameKeywords>();

    static GameManager gameManager;
    static DropOutline outline;
    public Animator cameraAnim;

    // Start is called before the first frame update
    void Start()
    {
        // get Game Manager
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        int lvlLength = gameManager.keywordsKelas.Length;
        
        // get outline
        outline = gameObject.GetComponent<DropOutline>();

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

            // update points
            gameManager.levels[0].lvlAnswered++;
            gameManager.levels[0].lvlPoints += keyword[number-1].keyPoints;

            // next question
            if (number != maxNumber) {
                number++;
                // changeNumber();

                // change question image
                image.sprite = keyword[number-1].keyArab;

                // put obj back
                StartCoroutine(ChangePos(y, 1f));
            }
            // finish
            else
            {
			    StartCoroutine(LoadWin());
            }
        }
        else
        {
            // put obj back
            StartCoroutine(ChangePos(y, 1f));
            cameraAnim.SetTrigger("Shake");
        }
    }

    IEnumerator LoadWin(){
		// puzzleAnim.SetTrigger("In");
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene("Win");
	}

    IEnumerator ChangePos(Choices obj, float delay){
		// puzzleAnim.SetTrigger("In");
		yield return new WaitForSeconds(delay);
        changeNumber();
		obj.DefaultPosition();
        outline.DefaultOutline();
	}
}
