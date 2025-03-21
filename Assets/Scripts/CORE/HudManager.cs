using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HudManager : MonoBehaviour
{
	public static HudManager instance = null;
	
	private int pv_max = 100;
	private int pv = 100;
	private int batterie_max = 40;
	private int batterie = 40;

	private Item item = Item.None;
	
	[SerializeField] private GameObject hud_item;
	[SerializeField] private GameObject hud_pv;
	[SerializeField] private GameObject hud_batterie;
	[SerializeField] private GameObject hud_message;
	[SerializeField] private GameObject panel_pause;
	[SerializeField] private List<Image> healthSegments;
	[SerializeField] private List<Image> batterySegments;
	
	[SerializeField] private float delay_message = 3.0f; //Temps où le message reste à l'écran
	private bool has_message = false;
	private float timer_message = 0f;
	
	public static bool pause = false;
	
	//Ajouter les sprites des items ici
	[SerializeField] private Sprite[] item_sprites;
	
	//Pattern singleton, pour récupérer facilement un objet unique dans le jeu
	void Awake(){
		if(instance == null){
			instance = this;
		}
	}
	
    // Start is called before the first frame update
    void Start()
    {
        if(hud_item == null || hud_pv == null || hud_message == null || hud_batterie == null){
			Debug.Log("hud mal configuré");
		}
		
		updateItem();
		updatePV();
		updateBatterie();
		hud_message.SetActive(false);
		
		AudioManager am = AudioManager.instance;
		am.PlayMusic(am.music_list.music1);
		
		panel_pause.SetActive(false);
		
    }

    // Update is called once per frame
    void Update()
    {
        if(has_message){
			//Si le temps d'affichage est terminé, on enlève le message de l'écran
			if(timer_message <= 0){
				timer_message = 0;
				has_message = false;
				hud_message.SetActive(false);
			} else {
				//On enlève le temps écoulé à chaque appel d'Update
				timer_message -= Time.deltaTime;
			}
		}
		
		//Si le joueur n'a plus de PV, on le redirige vers la scène de game over
		if(pv == 0){
			SceneManager.LoadScene("GameOver");
		}
		//Si on appuie sur P
		if(Input.GetKeyDown(KeyCode.P)){
			pause = !pause;
			panel_pause.SetActive(pause);
			if(pause){
				Time.timeScale = 0.0f;
			} else {
				Time.timeScale = 1.0f;
			}
		}
    }
	
	//Regarde si le joueur a tous ses PV
	public bool fullPV(){
		return pv == pv_max;
	}
	
	//Pour ajouter des PV
	public void addPV(int val){
		pv = Mathf.Min(pv_max, pv + val);
		updatePV();
	}
	
	//Pour enlever des PV
	public void subPV(int val){
		pv = Mathf.Max(0, pv - val);
		updatePV();
	}

	//Pour modifier le nombre de PV sur l'HUD
	//hud_pv.GetComponent<TMP_Text>().SetText("PV : " + pv.ToString());
	public void updatePV(){
        int activeSegmentsPV = pv / 10;
        for (int i = 0; i < healthSegments.Count; i++)
        {
            healthSegments[i].enabled = (i < activeSegmentsPV);
        }
	}

	public bool fullBatterie(){
		return batterie == batterie_max;
	}
	
	public int getBatterie(){
		return batterie;
	}
		//Pour ajouter des batteries
	public void addBatterie(int val){
		batterie = Mathf.Min(batterie_max, batterie + val);
		updateBatterie();
	}

		//Pour enlever des batteries
	public void subBatterie(int val){
		batterie = Mathf.Max(0, batterie - val);
		updateBatterie();
	}
	
	//Pour modifier le nombre de batterie sur l'HUD
	//public void updateBatterie (){
		//hud_batterie.GetComponent<TMP_Text>().SetText("Batterie : " + batterie.ToString());
	//}

	public void updateBatterie(){
    	int activeSegmentsBattery = batterie_max / 4;

		Debug.Log(batterie);
        for (int i = 0; i < batterySegments.Count; i++)
        {
            batterySegments[i].enabled = (batterie > i*activeSegmentsBattery);
        }
	}

	//Pour savoir si on a un item
	public bool hasItem(){
		return item != Item.None;
	}
	
	//Pour savoir si on a un item spécifique
	public bool gotItem(Item check){
		return item == check;
	}
	
	//Pour mettre un item
	public void addItem(Item new_item){
		item = new_item;
		updateItem();
	}
	
	//Pour enlever un item
	public void deleteItem(){
		item = Item.None;
		updateItem();
	}
	
	//Pour modifier l'icone en haut à droite
	public void updateItem(){	
		if(!hasItem()){ //Si on n'a pas d'item
			//On cache l'image en haut à droite
			hud_item.SetActive(false);
		} else {
			hud_item.SetActive(true);
			
			//Change le sprite en fonction de l'item
			switch(item){
				case Item.ClassicKey:
					hud_item.GetComponent<Image>().sprite = item_sprites[0];
					break;
			}
		}
	}

	//Afficher un message momentanément
	public void showMessage(string message){
		hud_message.SetActive(true);
		hud_message.GetComponent<TMP_Text>().SetText(message);
		has_message = false;
		timer_message = 0;
	}
	
	public void eraseMessage(){
		hud_message.SetActive(false);
	}
	
	public void showTimedMessage(string message){
		hud_message.SetActive(true);
		hud_message.GetComponent<TMP_Text>().SetText(message);
		
		timer_message = delay_message;
		has_message = true;
	}
}

//Liste des items du jeu
public enum Item
{
	None,
	ClassicKey,
}



