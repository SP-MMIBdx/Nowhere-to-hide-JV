using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NiveauSuivant : MonoBehaviour
{
    public string NomDeScene;

    public void AllerAuNiveau()
    {
        SceneManagement.LoadScene(NomDeScene);
        
    }

    void onTriggerEnter(Collider other)
    {
        AllerAuNiveau();
    }

}

