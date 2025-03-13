using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] private int batterie = 25;
	
	private bool active = true;
    //Si on touche son collider
	void OnTriggerEnter(Collider col){
		HudManager hud = HudManager.instance; //On récupère le hud
    	if (col.gameObject.tag == "Player" && active && !hud.fullBatterie()){
			//Redonne des PV au joueur
			hud.addBatterie(batterie);
			hud.showTimedMessage("Vous avez récupéré " + batterie + " Batterie.");
			Destroy(this.gameObject);
			active = false; //Evite de revenir dans le script une fois l'objet supprimé
			AudioManager am = AudioManager.instance;
			am.PlaySFX(am.sfx_list.sfx_heal);
    	}
	}
}
