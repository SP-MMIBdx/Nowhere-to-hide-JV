using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] private int batterie = 10;
	
	private bool active = true;
    //Si on touche son collider
	void OnTriggerEnter(Collider col)
{
    HudManager hud = HudManager.instance; // On récupère le HUD

    if (col.gameObject.tag == "Player" && active)
    {
        if (!hud.fullBatterie())
        {
            // Redonne une batterie au joueur
            hud.addBatterie(batterie);
            hud.showTimedMessage("Vous avez récupéré 1 Batterie.");
            active = false; // Évite de revenir dans le script
            AudioManager am = AudioManager.instance;
            am.PlaySFX(am.sfx_list.sfx_heal);
            Destroy(this.gameObject);
        }
        else
        {
            hud.showTimedMessage("Votre batterie est déjà pleine");
        }
    }
}
}
