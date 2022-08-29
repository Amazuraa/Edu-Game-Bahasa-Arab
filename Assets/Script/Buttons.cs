using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{
    private string btnMode;
    private string gameMode;

    static GameManager gameManager;

    public GameObject[] panels;
    public Selection[] panelSelect;
    public GameObject[] buttonsTop;
    public Animator anim;
    public bool mute = false;
    private AudioSource source;
	public AudioClip clip;

    public bool backUse = false;
    public string backMode = "";

    // Start is called before the first frame update
    void Start()
    {
		source = GetComponent<AudioSource>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        if (backUse) {
            backMode = gameManager.backGlobal;
            if (backMode != "") StartCoroutine(LoadSelect());
        }
    }

    public void MM_Title() {
        int i = 0;
        foreach (GameObject panel in panels)
        {
            if (i >= 4)
                break;

            panel.SetActive(false);
            i++;
        }
        panels[6].SetActive(false);

        foreach (GameObject button in buttonsTop)
        {   button.SetActive(true);   }

        if (mute)
            buttonsTop[2].SetActive(true);
        else
            buttonsTop[2].SetActive(false);

        source.clip = clip;
        source.Play();
        panels[0].SetActive(true);
    }

    public void MM_About() {
        int i = 0;
        foreach (GameObject panel in panels)
        {
            if (i >= 4)
                break;

            panel.SetActive(false);
            i++;
        }
        panels[6].SetActive(false);

        source.clip = clip;
        source.Play();
        panels[1].SetActive(true);
    }

    public void MM_Tutorial() {
        int i = 0;
        foreach (GameObject panel in panels)
        {
            if (i >= 4)
                break;

            panel.SetActive(false);
            i++;
        }
        panels[6].SetActive(false);

        source.clip = clip;
        source.Play();
        panels[6].SetActive(true);
    }

    public void MM_Select(string modeSelect) {
        int i = 0;
        foreach (GameObject panel in panels)
        {
            if (i >= 4)
                break;

            panel.SetActive(false);
            i++;
        }
        panels[6].SetActive(false);

        source.clip = clip;
        source.Play();

        foreach (GameObject button in buttonsTop)
        {   button.SetActive(false);   }

        panels[2].SetActive(true);
        panels[3].SetActive(true);

        foreach (Selection panel in panelSelect)
        {
            if (modeSelect == "Play")
                panel.PlayMode();
            else if (modeSelect == "Learning")
                panel.LearnMode();
        }
    }

    public void MM_Select_Nos(string modeSelect) {
        int i = 0;
        foreach (GameObject panel in panels)
        {
            if (i >= 4)
                break;

            panel.SetActive(false);
            i++;
        }
        panels[6].SetActive(false);

        foreach (GameObject button in buttonsTop)
        {   button.SetActive(false);   }

        panels[2].SetActive(true);
        panels[3].SetActive(true);

        foreach (Selection panel in panelSelect)
        {
            if (modeSelect == "Play")
                panel.PlayMode();
            else if (modeSelect == "Learning")
                panel.LearnMode();
        }
    }

    public void MM_Mute(bool mode) {
        if (mode) {
            panels[4].SetActive(false);
            panels[5].SetActive(true);
        }
        else {
            panels[4].SetActive(true);
            panels[5].SetActive(false);
        }

        gameManager.BGM_Mute(mode);
        mute = mode;
    }

    public void MM_Quit() {
        Application.Quit();
    }

    public void EventExercise(string _game_mode) {
        gameMode = _game_mode;

        source.clip = clip;
        source.Play();

        // Start Mode 
        StartCoroutine(LoadGame());
    }

    public void EventLearning(string _game_mode) {
        gameMode = _game_mode;

        source.clip = clip;
        source.Play();

        // Start Mode 
        StartCoroutine(LoadLearning());
    }

    public void EventHome(string mode) {
        source.clip = clip;
        source.Play();

        gameManager.backGlobal = mode;

        // Start Mode 
        StartCoroutine(LoadHome());
    }

    public void EventRestart() {
        // Start Mode 
        StartCoroutine(RestartGame());
    }

    public void EventEnd() {
        // Start Mode 
        StartCoroutine(LoadEnd());
    }

    IEnumerator LoadSelect() {
        yield return new WaitForSeconds(0f);
        MM_Select_Nos(backMode);
    }

    IEnumerator LoadGame() {
		gameManager.keywordsMode = gameMode;
		yield return new WaitForSeconds(.2f);
        // gameManager.BackupScore();
        gameManager.ResetScore();
		SceneManager.LoadScene("Exercise");
	}

    IEnumerator LoadLearning() {
		gameManager.keywordsMode = gameMode;

        yield return new WaitForSeconds(.2f);

		SceneManager.LoadScene("Learning");
    }

    IEnumerator RestartGame() {
		yield return new WaitForSeconds(2f);
        gameManager.ResetScore();
		SceneManager.LoadScene("Exercise");
	}

    IEnumerator LoadHome() {
		// puzzleAnim.SetTrigger("In");
		yield return new WaitForSeconds(.2f);
		SceneManager.LoadScene("Main_Menu");
	}

    IEnumerator LoadEnd() {
		// puzzleAnim.SetTrigger("In");
		yield return new WaitForSeconds(.5f);
		SceneManager.LoadScene("End");
	}
}
