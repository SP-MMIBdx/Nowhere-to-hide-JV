using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampeController : MonoBehaviour

{
    public Light LampeLumiere;
    private HudManager hud;
    private float cooldown = 1f;
    private float timerCooldown = 0;
    private bool isOn = false;

    void Start()
    {
        LampeLumiere = GetComponentInChildren<Light>();
        switchLight ();
        hud = HudManager.instance;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && hud.getBatterie() > 0) 
        {
            isOn = !isOn;
            switchLight();
        }
        
        //On enlève 1 batterie au joueur toutes les 0.1s
        if(isOn && timerCooldown <= 0){
            hud.subBatterie(1);
            timerCooldown = cooldown;
            Debug.Log($"test {timerCooldown}");

        } else {
            timerCooldown -= Time.deltaTime;
        }
        
        if (hud.getBatterie() == 0 && isOn){
            isOn = false;
            switchLight();
        }

        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.up * 10, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
        {
            if(hit.transform.gameObject.tag == "Enemy" && isOn){

                Debug.Log(hit.transform.name);
                hit.transform.gameObject.GetComponent<MoveForward>().SetCanMove(false);
            }
        }
    }

    private void switchLight (){
        if(isOn){
            LampeLumiere.intensity = 8;
        }
        else {
            LampeLumiere.intensity = 0;
        }
    }
}


