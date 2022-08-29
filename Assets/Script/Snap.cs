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

    private GameKeywords[] keywords;
    private int idxMode;

    public AudioSource source;
    public AudioClip clip;
    public AudioClip clip2;


    // Start is called before the first frame update
    void Start()
    {
        // get Game Manager
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

        int lvlLength = keywords.Length;
        
        // get outline
        outline = gameObject.GetComponent<DropOutline>();

        // loop for random answer
        for (int i = 0; i < maxNumber; i++) {
            int idx = Random.Range(0, lvlLength);
            keyword.Add(keywords[idx]);
        }

        // send delegate to choices
        changeChoices();

        // set first question image
        image.sprite = keyword[0].keyArab;

        // get level mode index
        int j = 0;
        foreach (GameLevels level in gameManager.levels)
        {
            if (gameManager.keywordsMode == level.lvlName)
                idxMode = j;
            
            j++;
        }

        // play first audio questions
        PlayQuestion();
    }
    
    public void checkAnswer(GameObject obj) {
        Choices y = obj.GetComponent<Choices>();
        string mode = gameManager.keywordsMode;

        // answer true
        if (y.objName == keyword[number-1].keyName) {

            // update points
            gameManager.levels[idxMode].lvlAnswered++;
            gameManager.levels[idxMode].lvlPoints += keyword[number-1].keyPoints;
        }
        else
        {
            // put obj back
            StartCoroutine(ChangePos(y, 1f));
            cameraAnim.SetTrigger("Shake");
        }

        // next question
        if (number != maxNumber) {
            number++;

            // change question image
            bool odd = (number % 2 == 0) ? true : false;
            StartCoroutine(ChangeImage(odd));

            // play audio question
            PlayQuestion();

            // put obj back
            StartCoroutine(ChangePos(y, 1f));
        }
        // finish
        else
            StartCoroutine(LoadWin());      
    }

    IEnumerator LoadWin() {
		yield return new WaitForSeconds(.2f);
		SceneManager.LoadScene("Win");
	}

    IEnumerator ChangePos(Choices obj, float delay) {
        changeNumber();
		yield return new WaitForSeconds(delay);
		obj.DefaultPosition();
        outline.DefaultOutline();
	}

    IEnumerator ChangeImage(bool x) {
		yield return new WaitForSeconds(1f);
        if (!x) image.sprite = keyword[number-1].keyArab;
        else image.sprite = keyword[number-1].keyImage;
    }

    public void PlayQuestion() {
        // set audio question
        if (number % 2 == 0) source.clip = clip;
        else source.clip = clip2;

        StartCoroutine(PlayDelay());
        // source.Play();

        // if (number % 2 != 0)
        //     StartCoroutine(PlayCheck());
    }

    IEnumerator PlayDelay() {
		yield return new WaitForSeconds(1f);
        source.Play();

        if (number % 2 != 0)
            StartCoroutine(PlayCheck());
    }

    IEnumerator PlayCheck() {
        bool stat = true;

        while (stat)
        {
            yield return new WaitForSeconds(1f);

            if (!source.isPlaying) {
                // Bug notes
                // if (number % 2 != 0) {
                    source.clip = keyword[number-1].keyClip;
                    source.Play();
                // }

                stat = false;
            }
        }
    }
}
