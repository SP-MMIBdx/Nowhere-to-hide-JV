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

    void Start(){
        HideOptions();
        HideTutorial();
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

	public void PlayGame(){
		SceneManager.LoadScene("Level1");
    
    }

	public void QuitGame(){
		Application.Quit();
	}
}
