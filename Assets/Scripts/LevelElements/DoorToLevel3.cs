using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToLevel3 : MonoBehaviour
{
	[SerializeField] private GameObject doorlvl3;
	
	private bool active = true;
    //Si on touche son collider
	void OnTriggerEnter(Collider col){
    	if (col.gameObject.tag == "Player" && active){
        	HudManager hud = HudManager.instance; //On récupère le hud
			
			//Si le joueur a la clé dans son inventaire
			if(hud.gotItem(Item.ClassicKey)){
				hud.deleteItem();
				hud.showTimedMessage("Level 3.");
				Destroy(doorlvl3);
				active = false; //Evite de revenir dans le script une fois l'objet supprimé
				AudioManager am = AudioManager.instance;
				am.PlaySFX(am.sfx_list.sfx_lock);
				hud.showMessage("Level 3");
                SceneManager.LoadScene("Level3");
			} else{
				hud.showMessage("Vous n'avez pas le badge.");
			}

    	}
	}
	
	//Si on sort du collider
	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player" && active){
			HudManager hud = HudManager.instance;
			hud.eraseMessage();
		}
	}
}
