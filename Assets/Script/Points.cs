using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Text pointDisplay;
	public Animator pointAnim;
	static GameManager gameManager;

	void Start(){
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}

	void Update(){
		pointDisplay.text = gameManager.levels[0].lvlAnswered + "/6";
	}

	public void Anim(){
		pointAnim.SetTrigger("Pop");
	}
}
