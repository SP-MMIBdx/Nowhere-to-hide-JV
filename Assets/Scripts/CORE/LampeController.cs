using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampeController : MonoBehaviour

{
public Light LampeLumiere;

    
/*   {
        if (Input.GetMouseButtonDown(0)) 
        {
            ToggleLampeLumiere();
        }
*/ 

    void Start()
    {
        LampeLumiere = GetComponentInChildren<Light>();
        LampeLumiere.intensity = (0);
    }

    void Update()
    {

                if (Input.GetMouseButtonDown(0)) 
        {
            LampeLumiere.intensity = (8);
        }
                if (Input.GetMouseButtonDown(1)) 
        {
            LampeLumiere.intensity = (0);
        }

    }
}


