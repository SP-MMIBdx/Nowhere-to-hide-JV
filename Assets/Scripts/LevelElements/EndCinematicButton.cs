using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject buttonQuitter;
    
        public void Quitter(){
		SceneManager.LoadScene("MainMenu");  
    }
        
}
