using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject panelOptions;
    public GameObject panelTutorial;

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
        Debug.Log("Play");
    }

    public void QuitGame(){
        Debug.Log("Quit");
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
