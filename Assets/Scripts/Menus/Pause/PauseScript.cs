using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject panelOptions; 
    public GameObject panelMainmenu;
    public GameObject buttonQuit;
    public GameObject buttonQuitoptions;

    void Start (){
        HideOptions();
    }

    public void ShowOptions(){
        panelOptions.SetActive(true);

    }

    public void HideOptions(){
        panelOptions.SetActive(false);

    }
    public void QuitGame(){
		Application.Quit();
	}

    public void goToMainMenu(){
		SceneManager.LoadScene("MainMenu");
	}

}
