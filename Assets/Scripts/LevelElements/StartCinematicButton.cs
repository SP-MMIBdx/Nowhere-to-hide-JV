using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCinematicButton : MonoBehaviour
{
    public GameObject buttonStartGame;
    
        public void StartGame(){
		SceneManager.LoadScene("Level1");  
    }
        
    }