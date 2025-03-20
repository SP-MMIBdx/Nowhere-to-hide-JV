using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorFinishGame : MonoBehaviour
{
	[SerializeField] private GameObject doorfinish;
	
	private bool active = true;
    //Si on touche son collider
	void OnTriggerEnter(Collider col){
    	if (col.gameObject.tag == "Player" && active){
        	HudManager hud = HudManager.instance; //On récupère le hud
			
			//Si le joueur a la clé dans son inventaire
			if(hud.gotItem(Item.ClassicKey)){
				hud.deleteItem();
				hud.showTimedMessage("Escape!");
				Destroy(doorfinish);
				active = false; //Evite de revenir dans le script une fois l'objet supprimé
				AudioManager am = AudioManager.instance;
				am.PlaySFX(am.sfx_list.sfx_lock);
                SceneManager.LoadScene("EndCinematic");
			} else{
				hud.showMessage("Vous n'avez pas la clé.");
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

