using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NiveauSuivant : MonoBehaviour
{
    public string NomDeScene;

    public void AllerAuNiveau()
    {
        SceneManager.LoadScene(NomDeScene); 
    }

    void onTriggerEnter(Collider other)
    {
        AllerAuNiveau();
        Debug.Log("test");
    }

}

