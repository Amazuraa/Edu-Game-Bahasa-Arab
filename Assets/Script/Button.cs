using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Button : MonoBehaviour
{
    public string btnMode;

    public Animator anim;
    private AudioSource source;
	public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
		source = GetComponent<AudioSource>();
    }

    void OnMouseOver(){

		if(Input.GetMouseButtonDown(0)){
			source.clip = clip;
			source.Play();

            switch (btnMode)
            {
                case "Start":
                    StartCoroutine(LoadGame());
                    break;
                case "Restart":
                    StartCoroutine(RestartGame());
                    break;
                case "Home":
                    StartCoroutine(Home());
                    break;
            }
		}
	}

    IEnumerator LoadGame(){
		// puzzleAnim.SetTrigger("In");
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene("Exercise");
	}

    IEnumerator RestartGame(){
		// puzzleAnim.SetTrigger("In");
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene("Exercise");
	}

    IEnumerator Home(){
		// puzzleAnim.SetTrigger("In");
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene("Main_Menu");
	}
}
