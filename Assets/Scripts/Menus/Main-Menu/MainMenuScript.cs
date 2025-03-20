using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject panelOptions;
    public GameObject panelTutorial;
    public GameObject panelQuit;
    public GameObject panelStartgame;
    public GameObject panelCredits;
    public GameObject panelRights;

    void Start(){
        HideOptions();
        HideTutorial();
        HideRights();
        HideCredits();
    }

    public void ShowOptions(){
        panelOptions.SetActive(true);
    }

    public void HideOptions(){
        panelOptions.SetActive(false);
    }

        public void ShowTutorial(){
        panelTutorial.SetActive(true);
    }

    public void HideTutorial(){
        panelTutorial.SetActive(false);
    }

        public void ShowCredits(){
        panelCredits.SetActive(true);
    }

    public void HideCredits(){
        panelCredits.SetActive(false);
    }

        public void ShowRights(){
        panelRights.SetActive(true);
    }

    public void HideRights(){
        panelRights.SetActive(false);
    }

	public void PlayGame(){
		SceneManager.LoadScene("StartCinematic");  
    }

	public void QuitGame(){
		Application.Quit();
	}


}
