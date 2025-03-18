using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampeController : MonoBehaviour

{
public Light LampeLumiere;
private HudManager hud;
private float cooldown = 1f;
private float timerCooldown = 0;

    void Start()
    {
        LampeLumiere = GetComponentInChildren<Light>();
        LampeLumiere.intensity = (0);
        hud = HudManager.instance;
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
        
			//On enlève 1 batterie au joueur toutes les 0.1s
			if(LampeLumiere.intensity == (8) && timerCooldown <= 0){
				hud.subBatterie(1);
				timerCooldown = cooldown;
                Debug.Log($"test {timerCooldown}");

			} else {
				timerCooldown -= Time.deltaTime;
			}
            
            if (hud.getBatterie() == 0){
                LampeLumiere.intensity = (0);
            }
		}
}


