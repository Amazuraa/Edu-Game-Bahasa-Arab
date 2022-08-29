using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    	public Text pointDisplay;
	public Animator pointAnim;
	static GameManager gameManager;
	private int idxMode;

	void Start(){
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

	   // get level mode index
        int j = 0;
        foreach (GameLevels level in gameManager.levels)
        {
            if (gameManager.keywordsMode == level.lvlName)
                idxMode = j;
            
            j++;
        }
	}

	void Update(){
		pointDisplay.text = gameManager.levels[idxMode].lvlAnswered + "/10";
	}

	public void Anim(){
		pointAnim.SetTrigger("Pop");
	}
}
