using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
	private Transform player;
	public float speed = 0.1f;
  private bool canMove = true;
  private float stopCooldown = 0.5f;
	
	private float stop_distance = 3f;
	
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
      if(canMove){
        //Si la distance entre le joueur et l'ennemi est inférieur à stop_distance et qu'on n'est pas en pause
        if(Vector3.Distance(player.transform.position, transform.position) < stop_distance && !HudManager.pause){
          Vector3 playerPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
          transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
        }
      } else {
        if(stopCooldown > 0){
          stopCooldown -= Time.deltaTime;
        } else {
          canMove = true;
        }

      }
    }

    public void SetCanMove(bool val){
      canMove = val;
      stopCooldown = 0.5f;
    }
}