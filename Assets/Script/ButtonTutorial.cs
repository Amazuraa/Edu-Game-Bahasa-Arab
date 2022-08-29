using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTutorial : MonoBehaviour
{
    public GameObject[] tutorialPanels;
    public GameObject btnOk;
    public int indexPanel;
    public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    void OnEnable()
    {
        // first run
        ResetAll();
    }

    void HideAll()
    {
        btnOk.SetActive(false);

        foreach (GameObject panel in tutorialPanels)
        {
            panel.SetActive(false);
        }
    }

    public void ResetAll()
    {
        HideAll();
        tutorialPanels[0].SetActive(true);
        btnOk.SetActive(true);
    }

    public void NavigatePanel()
    {
        HideAll();
        tutorialPanels[indexPanel].SetActive(true);
        indexPanel++;
        
        source.clip = clip;
        source.Play();
    }

    public void ModePanel(int i)
    {
        indexPanel = i;
        NavigatePanel();
    }
}


